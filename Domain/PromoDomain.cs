using AutoMapper;
using FluentResults;
using ms_partnership.Data;
using ms_partnership.Interfaces;
using ms_partnership.Models.Entities;
using ms_partnership.Models.Entities.Dtos.Promo;
using ms_partnership.Models.Pagination;

namespace ms_partnership.Domain
{
    public class PromoDomain : IPromo
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public PromoDomain(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadPromoDto Add(AddPromoDto dto)
        {
            Promo promo = _mapper.Map<Promo>(dto);
            _context.Promos.Add(promo);
            _context.SaveChanges();
            ReadPromoDto promoDto = _mapper.Map<ReadPromoDto>(promo);
            return promoDto;
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
            Promo promo = _context.Promos.FirstOrDefault(promo => promo.Id == id);
            if (promo != null)
            {
                _context.Remove(promo);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<ReadPromoDto> SearchAll()
        {
            var lista = _context.Promos.ToList();
            IEnumerable<ReadPromoDto> readPromoDtos = _mapper.Map<List<ReadPromoDto>>(lista);
            return readPromoDtos;
        }

        public ReadPromoDto SearchById(Guid id)
        {
            Promo promo = _context.Promos.FirstOrDefault(promo => promo.Id == id);
            ReadPromoDto promoDto = _mapper.Map<ReadPromoDto>(promo);
            return promoDto;
        }

        public ReadPromoDto Update(Guid id, UpdatePromoDto dto)
        {
            Promo promo = _context.Promos.FirstOrDefault(promo => promo.Id == id);
            if(promo != null)
            {
                _mapper.Map(dto, promo);
                ReadPromoDto promoDto = _mapper.Map<ReadPromoDto>(promo);
                _context.SaveChanges();
                return promoDto;
            }
            return null;
        }

        public virtual PromoPagination promoPaginationPeriod(int page, int itemsPage, DateTime period)
        {
            int skip = itemsPage * (page - 1);
            int take = itemsPage;

            List<Promo> promos = _context.Promos
            .Where(promo => promo.Created.Month == period.Month
            && promo.Created.Year == period.Year)
            .OrderBy(promo => promo.Created)
            .Skip(skip)
            .Take(take)
            .ToList();

            int totalPromos = promos.Count();

            int totalPages = (int)Math.Ceiling((double)totalPromos / (double)itemsPage);

            return new PromoPagination(_mapper.Map<List<ReadPromoDto>>(promos), totalPages, page, totalPromos);
        }

        public virtual PromoPagination promoPaginationCompany(Guid companyId, int page, int itemsPage)
        {
            int skip = itemsPage * (page - 1);
            int take = itemsPage;
            string companyIdString = companyId.ToString();

            List<Promo> promos = _context.Promos
            .Where(promoCompany => promoCompany.CompanyId.ToString().Contains(companyIdString))
            .OrderBy(promo => promo.Created)
            .Skip(skip)
            .Take(take)
            .ToList();

            int totalPromos = promos.Count();

            int totalPages = (int)Math.Ceiling((double)totalPromos / (double)itemsPage);

            return new PromoPagination(_mapper.Map<List<ReadPromoDto>>(promos), totalPages, page, totalPromos);
        }
    }
}