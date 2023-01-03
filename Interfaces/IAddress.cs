using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ms_partnership.Models.Entities.Dtos.Address;

namespace ms_partnership.Interfaces
{
    public interface IAddress : IBaseGuid<AddAddressDto, ReadAddressDto>, IUpdate<UpdateAddressDto, ReadAddressDto>
    {
        Task<ReadAddressDto> AddAsync(AddAddressDto dto);
    }
}