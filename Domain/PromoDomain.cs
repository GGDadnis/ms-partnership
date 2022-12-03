using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentResults;
using ms_partnership.Data;
using ms_partnership.Interfaces;
using ms_partnership.Models.Entities;
using ms_partnership.Models.Entities.Dtos.Promo;

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
    }
}