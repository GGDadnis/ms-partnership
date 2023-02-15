using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ms_partnership.Models.Entities.Dtos.Address
{
    public class AddAddressDto
    {
        [Required(ErrorMessage = "The field Cep is required")]
        [Column("cep")]
        public string Cep { get; set; }

        [Column("complemento")]
        public string? Complemento { get; set; }

        [Column("company_id")]
        [DefaultValue(null)]
        public Guid? CompanyId { get; set; } = null;

        [Column("user_id")]
        [DefaultValue(null)]
        public Guid? UserId { get; set; } = null;
    }
}