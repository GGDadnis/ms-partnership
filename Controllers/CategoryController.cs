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
        private readonly ICategory _interface;

        public CategoryController(ICategory interfaceCategory)
        {
            _interface = interfaceCategory;
        }

        [HttpGet]
        public IActionResult getAllCategorys()
        {
            IEnumerable<ReadCategoryDto> categorys = _interface.SearchAll();

            return Ok(categorys);
        }

        [HttpGet("{id}")]
        public IActionResult getCategoryById(Guid id)
        {
            ReadCategoryDto category = _interface.SearchById(id);

            if (category != null)
            {
                return Ok(category);
            }

            return BadRequest("Category not found!");

        }

        [HttpPost]
        public IActionResult createCategory(AddCategoryDto objCategory)
        {

            ReadCategoryDto category = _interface.Add(objCategory);

            return Ok(category);
        }

        [HttpPut("{id}")]
        public IActionResult updateCategory(Guid id, UpdateCategoryDto updatedCategory)
        {
            ReadCategoryDto category = _interface.Update(id, updatedCategory);

            if (category != null)
            {
                return Ok(category);
            }

            return BadRequest("Fail! when updating category");
        }

        [HttpDelete("{id}")]
        public IActionResult deleteCategory(Guid id)
        {
            bool resultDelete = _interface.Remove(id);

            if (resultDelete)
            {
                return Ok("Category deleted!");
            }

            return BadRequest("Fail! Ops something went wrong");
        }
    }
}