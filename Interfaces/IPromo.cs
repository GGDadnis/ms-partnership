using ms_partnership.Models.Entities.Dtos.Promo;

namespace ms_partnership.Interfaces
{
    public interface IPromo : IBaseGuid<AddPromoDto, ReadPromoDto>, IUpdate<UpdatePromoDto, ReadPromoDto>
    {
        
    }
}