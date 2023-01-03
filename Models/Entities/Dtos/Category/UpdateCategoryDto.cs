using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ms_partnership.Models.Entities.Dtos.Category
{
    public class UpdateCategoryDto
    {
        [Required(ErrorMessage = "The field Name is required")]
        [Column("name")]
        public string Name { get; set; }
    }
}