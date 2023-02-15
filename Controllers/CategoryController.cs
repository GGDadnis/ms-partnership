using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ms_partnership.Interfaces;
using ms_partnership.Models.Entities;
using ms_partnership.Models.Entities.Dtos.Category;

namespace ms_partnership.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory _interfaces;

        public CategoryController(ICategory interfaceCategory)
        {
            _interfaces = interfaceCategory;
        }

        [HttpPost]
        public IActionResult createCategory(AddCategoryDto dto)
        {
            var category = _interfaces.Add(dto);
            if (category != null)
            {
                return Ok(category);
            }

            return BadRequest("Fail to create category");
        }

        [HttpGet]
        public IActionResult getAllCategories()
        {
            var categories = _interfaces.SearchAll();
            if (categories != null)
            {
                return Ok(categories);
            }
            return BadRequest("Fail to find categories");
        }

        [HttpGet("{id}")]
        public IActionResult getCategoryById(Guid id)
        {
            ReadCategoryDto category = _interfaces.SearchById(id);

            if (category != null)
            {
                return Ok(category);
            }

            return BadRequest("Fail to find category");

        }


        [HttpPut("{id}")]
        public IActionResult updateCategory(Guid id, UpdateCategoryDto updatedCategory)
        {
            ReadCategoryDto category = _interfaces.Update(id, updatedCategory);

            if (category != null)
            {
                return Ok(category);
            }

            return BadRequest("Fail to update category");
        }

        [HttpDelete("{id}")]
        public IActionResult deleteCategory(Guid id)
        {
            bool resultDelete = _interfaces.Remove(id);

            if (resultDelete)
            {
                return Ok("Category deleted!");
            }

            return BadRequest("Fail to delete category");
        }
    }
}