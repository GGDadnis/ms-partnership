using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ms_partnership.Models.Entities.Dtos.Category
{
    public class ReadCategoryDto
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [JsonIgnore]
        public virtual List<Models.Entities.Company> Companies { get; set; }
    }
}