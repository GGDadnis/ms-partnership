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
        public string Cep { get; set; }
        public string? Complemento { get; set; }
        public Guid? CompanyId { get; set; } = null;
        public Guid? UserId { get; set; } = null;
    }
}