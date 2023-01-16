using ms_partnership.Models.Entities.Dtos.Promo;
using ms_partnership.Models.Pagination;

namespace ms_partnership.Interfaces
{
    public interface IPromo : IBaseGuid<AddPromoDto, ReadPromoDto>, IUpdate<UpdatePromoDto, ReadPromoDto>
    {
        PromoPagination promoPaginationPeriod(int page, int itemsPage, DateTime period);
        PromoPagination promoPaginationCompany(Guid companyId, int page, int itemsPage);

    }
}