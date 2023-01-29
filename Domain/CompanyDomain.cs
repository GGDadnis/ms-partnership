using System.Xml;
using AutoMapper;
using FluentResults;
using ms_partnership.Data;
using ms_partnership.Interfaces;
using ms_partnership.Models.Entities;
using ms_partnership.Models.Entities.Dtos.Company;
using ms_partnership.Service;

namespace ms_partnership.Domain
{
    public class CompanyDomain : ICompany
    {
         private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly AmazonS3Service _amazonS3Service;

        public CompanyDomain(AppDbContext context, IMapper mapper, AmazonS3Service amazonS3Service)
        {
            _context = context;
            _mapper = mapper;
            _amazonS3Service = amazonS3Service;
        }

        public ReadCompanyDto Add(AddCompanyDto dto)
        {
            if (!String.IsNullOrEmpty(dto.LogoImg))
                dto.LogoImg = SendBase64ImageToS3(dto.LogoImg);
            Company company = _mapper.Map<Company>(dto);
            Category category = _context.Categories.FirstOrDefault(category => category.Id == dto.CategoryId);
            if (category == null){
                company.Category = null;
                return _mapper.Map<ReadCompanyDto>(company);
            }
            if (!dto.LogoImg.Contains("ERROR")){
                _context.Companies.Add(company);
                _context.SaveChanges();
            }
            ReadCompanyDto companyDto = _mapper.Map<ReadCompanyDto>(company);
            return companyDto;
        }

        public Result IdValidate(Guid id)
        {
            if (id == null)
            {
                return Result.Fail("");
            }
            return Result.Ok();
        }

        public bool Remove(Guid id)
        {
            Company company = _context.Companies.FirstOrDefault(company => company.Id == id);
            if (company != null)
            {
                if (!String.IsNullOrEmpty(company.LogoImg)){
                    var response = _amazonS3Service.DeleteAsync(company.LogoImg);
                    while (!response.IsCompleted){}
                    if (!response.IsCompletedSuccessfully)
                        company.LogoImg = "DELETE_ERROR";
                }
                if (!company.LogoImg.Contains("ERROR")){
                    _context.Remove(company);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            return false;
        }

        public IEnumerable<ReadCompanyDto> SearchAll()
        {
            var lista = _context.Companies.Where(company => company.Active == true).ToList();
            IEnumerable<ReadCompanyDto> readCompanyDtos = _mapper.Map<List<ReadCompanyDto>>(lista);
            return readCompanyDtos;
        }

        public ReadCompanyDto SearchById(Guid id)
        {
            Company company = _context.Companies.FirstOrDefault(company => company.Id == id);
            ReadCompanyDto companyDto = _mapper.Map<ReadCompanyDto>(company);
            return companyDto;
        }

        public ReadCompanyDto Update(Guid id, UpdateCompanyDto dto)
        {
            Category category = _context.Categories.FirstOrDefault(category => category.Id == dto.CategoryId);
            if (category == null)
                return null;
            Company company = _context.Companies.FirstOrDefault(company => company.Id == id);
            if(company != null)
            {
                if (!String.IsNullOrEmpty(dto.LogoImg)){
                    dto.LogoImg = SendBase64ImageToS3(dto.LogoImg);
                    if (!String.IsNullOrEmpty(company.LogoImg))
                        _amazonS3Service.DeleteAsync(company.LogoImg);
                }
                _mapper.Map(dto, company);
                ReadCompanyDto companyDto = _mapper.Map<ReadCompanyDto>(company);
                if (!dto.LogoImg.Contains("ERROR"))
                    _context.SaveChanges();
                return companyDto;
            }
            return null;
        }

        public ReadCompanyDto LogicalRemove(Guid id){
            Company company = _context.Companies.FirstOrDefault(company => company.Id == id);
            if(company != null)
            {
                if (!String.IsNullOrEmpty(company.LogoImg)){
                    var response = _amazonS3Service.DeleteAsync(company.LogoImg);
                    while (!response.IsCompleted){}
                    if (!response.IsCompletedSuccessfully)
                        company.LogoImg = "DELETE_ERROR";
                    else
                        company.LogoImg = "DELETED";
                }
                company.Active = false;
                ReadCompanyDto companyDto = _mapper.Map<ReadCompanyDto>(company);
                if (!company.LogoImg.Contains("ERROR"))
                    _context.SaveChanges();
                return companyDto;
            }
            return null;
        }

        private string SendBase64ImageToS3(string base64Image){
            // Converter imagem base64
            Stream filestream;
            try{
                filestream = ConvertBase64Image(base64Image);
            }catch{
                return "CONVERTION_ERROR";
            }
            // Obter o formato da imagem original
            int length = base64Image.LastIndexOf(';') - base64Image.LastIndexOf("image/") - 6;
            var formatoImagem = base64Image.Substring(base64Image.LastIndexOf("image/") + 6, length);
            // Gerar um nome do arquivo a partir de um Guid
            var key = Guid.NewGuid().ToString() + '.' + formatoImagem;
            // Enviar imagem para a S3 e aguardar a resposta
            var response = _amazonS3Service.SendAsync(filestream, key);
            while (!response.IsCompleted){}
            if (response.IsCompletedSuccessfully)
                return response.Result;
            return "SEND_ERROR";
        }

         private Stream ConvertBase64Image(string base64Image){
            var contentBase64 = base64Image.Substring(base64Image.LastIndexOf(',') + 1);
            byte[] bytes = Convert.FromBase64String(contentBase64);
            Stream filestream = new MemoryStream(bytes);
            return filestream;
         }
    }
}