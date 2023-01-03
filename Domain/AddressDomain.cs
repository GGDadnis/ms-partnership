using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using ms_partnership.Data;
using ms_partnership.Interfaces;
using ms_partnership.Models.Entities;
using ms_partnership.Models.Entities.Dtos.Address;
using ms_partnership.Models.External;
using ms_partnership.Service;

namespace ms_partnership.Domain
{
    public class AddressDomain : IAddress
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        private readonly ViaCepService _serviceCep;


        public AddressDomain(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
            _serviceCep = new ViaCepService();
        }

        public ReadAddressDto Add(AddAddressDto obj)
        {
            throw new NotImplementedException();
        }

        public async Task<ReadAddressDto> AddAsync(AddAddressDto dto)
        {
            ResponseViaCep responseCep = await _serviceCep.buscarCep(dto.Cep);

            responseCep.Complemento = dto.Complemento;

            if (responseCep != null)
            {
                Address address = _mapper.Map<Address>(responseCep);

                _context.Address.Add(address);
                _context.SaveChanges();

                ReadAddressDto addressDto = _mapper.Map<ReadAddressDto>(address);

                return addressDto;
            }

            return null;
        }

        public Result IdValidate(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReadAddressDto> SearchAll()
        {
            throw new NotImplementedException();
        }

        public ReadAddressDto SearchById(Guid id)
        {
            throw new NotImplementedException();
        }

        public ReadAddressDto Update(Guid id, UpdateAddressDto obj)
        {
            throw new NotImplementedException();
        }
    }
}