using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ms_partnership.Models.Entities.Dtos.Address
{
    public class UpdateAddressDto
    {
        [Required(ErrorMessage = "The Field Cep is required")]
        [Column("cep")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "The Field Logradouro is required")]
        [Column("logradouro")]
        public string Logradouro { get; set; }


        [Required(ErrorMessage = "The Field Bairro is required")]
        [Column("bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "The Field Localidade is required")]
        [Column("localidade")]
        public string Localidade { get; set; }

        [Required(ErrorMessage = "The Field Uf is required")]
        [Column("uf")]
        public string Uf { get; set; }

        [Column("complemento")]
        public string Complemento { get; set; } = "";
    }
}