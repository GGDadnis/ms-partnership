using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ms_partnership.Models.Entities;
using ms_partnership.Models.Entities.Dtos.Address;
using ms_partnership.Models.External;

namespace ms_partnership.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<AddAddressDto, Address>();
            CreateMap<UpdateAddressDto, Address>();
            CreateMap<Address, ReadAddressDto>();

            CreateMap<ResponseViaCep, Address>();
        }
    }
}