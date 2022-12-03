using AutoMapper;
using ms_partnership.Models.Entities;
using ms_partnership.Models.Entities.Dtos.Promo;

namespace ms_partnership.Profiles
{
    public class PromoProfiles : Profile
    {
        public PromoProfiles()
        {
            CreateMap<AddPromoDto, Promo>();
            CreateMap<Promo, ReadPromoDto>();
            CreateMap<UpdatePromoDto, Promo>();
        }
    }
}