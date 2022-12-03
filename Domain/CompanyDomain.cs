using AutoMapper;
using FluentResults;
using ms_partnership.Data;
using ms_partnership.Interfaces;
using ms_partnership.Models.Entities;
using ms_partnership.Models.Entities.Dtos.Company;

namespace ms_partnership.Domain
{
    public class CompanyDomain : ICompany
    {
         private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CompanyDomain(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadCompanyDto Add(AddCompanyDto dto)
        {
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
                _mapper.Map(dto, company);
                ReadCompanyDto companyDto = _mapper.Map<ReadCompanyDto>(company);
                _context.SaveChanges();
                return companyDto;
            }
            return null;
        }
    }
}