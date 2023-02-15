using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ms_partnership.Models.Entities.Dtos.Login;

namespace ms_partnership.Interfaces
{
    public interface ILogin : IBaseGuid<AddLoginDto, ReadLoginDto>, IUpdate<UpdateLoginDto, ReadLoginDto>
    {
    }
}