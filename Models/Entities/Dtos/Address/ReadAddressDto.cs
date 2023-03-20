using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ms_partnership.Models.Entities.Dtos.Address
{
    public class ReadAddressDto
    {
        public Guid Id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public string Complemento { get; set; }
        public Guid? CompanyId { get; set; } = null;
        public Guid? UserId { get; set; }
        public virtual Models.Entities.Company? Company { get; set; }
        public virtual Models.Entities.User? User { get; set; }
    }
}