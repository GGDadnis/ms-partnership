using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ms_partnership.Models.Entities.Dtos.Category;

namespace ms_partnership.Interfaces
{
    public interface ICategory : IBaseGuid<AddCategoryDto, ReadCategoryDto>, IUpdate<UpdateCategoryDto, ReadCategoryDto>
    {

    }
}