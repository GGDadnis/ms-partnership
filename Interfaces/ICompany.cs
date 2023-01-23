using ms_partnership.Models.Entities.Dtos.Company;

namespace ms_partnership.Interfaces
{
    public interface ICompany : IBaseGuid<AddCompanyDto, ReadCompanyDto>, IUpdate<UpdateCompanyDto, ReadCompanyDto>
    {
        ReadCompanyDto LogicalRemove(Guid id);
    }
}