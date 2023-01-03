using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ms_partnership.Models.Entities.Dtos.Address
{
    public class ReadAddressDto
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("cep")]
        public string Cep { get; set; }

        [Column("logradouro")]
        public string Logradouro { get; set; }


        [Column("bairro")]
        public string Bairro { get; set; }

        [Column("localidade")]
        public string Localidade { get; set; }

        [Column("uf")]
        public string Uf { get; set; }

        [Column("complemento")]
        public string Complemento { get; set; }


    }
}