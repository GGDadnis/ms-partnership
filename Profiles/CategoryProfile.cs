using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ms_partnership.Models.Entities;
using ms_partnership.Models.Entities.Dtos.Category;

namespace ms_partnership.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<AddCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<Category, ReadCategoryDto>();


        }

    }
}