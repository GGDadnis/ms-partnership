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
using ms_partnership.Models.Entities.Dtos.Category;

namespace ms_partnership.Domain
{
    public class CategoryDomain : ICategory
    {

        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public CategoryDomain(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public ReadCategoryDto Add(AddCategoryDto obj)
        {
            Category model = _mapper.Map<Category>(obj);

            _context.Add(model);
            _context.SaveChanges();

            ReadCategoryDto categoryRead = _mapper.Map<ReadCategoryDto>(model);

            return categoryRead;
        }

        public Result IdValidate(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Guid id)
        {
            Category categoryObj = _context.Category.FirstOrDefault(category => category.Id == id);

            if (categoryObj != null)
            {
                _context.Remove(categoryObj);
                _context.SaveChanges();

                return true;
            }

            return false;
        }

        public IEnumerable<ReadCategoryDto> SearchAll()
        {
            List<Category> allCategorys = _context.Category.ToList();

            List<ReadCategoryDto> categorysMapped = _mapper.Map<List<ReadCategoryDto>>(allCategorys);

            return categorysMapped;
        }

        public ReadCategoryDto SearchById(Guid id)
        {
            Category category = _context.Category.FirstOrDefault(category => category.Id == id);

            if (category != null)
            {
                return _mapper.Map<ReadCategoryDto>(category);
            }

            return null;
        }

        public ReadCategoryDto Update(Guid id, UpdateCategoryDto obj)
        {
            Category categoryDb = _context.Category.FirstOrDefault(category => category.Id == id);

            if (categoryDb != null)
            {
                _mapper.Map(obj, categoryDb);

                _context.SaveChanges();

                return _mapper.Map<ReadCategoryDto>(categoryDb);
            }

            return null;
        }
    }
}