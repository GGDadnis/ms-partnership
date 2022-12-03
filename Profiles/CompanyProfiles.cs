using AutoMapper;
using ms_partnership.Models.Entities;
using ms_partnership.Models.Entities.Dtos.Company;

namespace ms_partnership.Profiles
{
    public class CompanyProfiles : Profile
    {
        public CompanyProfiles()
        {
            CreateMap<AddCompanyDto, Company>();
            CreateMap<Company, ReadCompanyDto>();
            CreateMap<UpdateCompanyDto, Company>();
        }
    }
}