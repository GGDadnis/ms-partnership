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
            if (dto.LogoImg != null || dto.LogoImg != "")
                dto.LogoImg = EnviarImagemS3(dto.LogoImg);
            Company company = _mapper.Map<Company>(dto);
            _context.Companies.Add(company);
            _context.SaveChanges();
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
                if (company.LogoImg != null || company.LogoImg != "")
                    _amazonS3Service.DeleteAsync(company.LogoImg);
                _context.Remove(company);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<ReadCompanyDto> SearchAll()
        {
            var lista = _context.Companies.ToList();
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
            Company company = _context.Companies.FirstOrDefault(company => company.Id == id);
            if(company != null)
            {
                if (dto.LogoImg != null || dto.LogoImg != ""){
                    dto.LogoImg = EnviarImagemS3(dto.LogoImg);
                    if (company.LogoImg != null || company.LogoImg != "")
                        _amazonS3Service.DeleteAsync(company.LogoImg);
                }
                _mapper.Map(dto, company);
                ReadCompanyDto companyDto = _mapper.Map<ReadCompanyDto>(company);
                _context.SaveChanges();
                return companyDto;
            }
            return null;
        }

        private string EnviarImagemS3(string imagemBase64){
            var conteudoBase64 = imagemBase64.Substring(imagemBase64.LastIndexOf(',') + 1);
            byte[] bytes = Convert.FromBase64String(conteudoBase64);
            Stream filestream = new MemoryStream(bytes);
            int length = imagemBase64.LastIndexOf(';') - imagemBase64.LastIndexOf("image/") - 6;
            var formatoImagem = imagemBase64.Substring(imagemBase64.LastIndexOf("image/") + 6, length);
            var key = Guid.NewGuid().ToString() + '.' + formatoImagem;
            var response = _amazonS3Service.SendAsync(filestream, key);
            while (!response.IsCompleted){}
            if (response.IsCompletedSuccessfully)
                return response.Result;
            return "";
        }
    }
}