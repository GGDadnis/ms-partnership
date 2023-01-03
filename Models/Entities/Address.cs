using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ms_partnership.Models.Entities
{
    [Table("address")]
    public class Address
    {

        [Key]
        [Required]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("cep")]
        public string Cep { get; set; }

        [Required]
        [Column("logradouro")]
        public string Logradouro { get; set; }

        [Required]
        [Column("bairro")]
        public string Bairro { get; set; }

        [Required]
        [Column("localidade")]
        public string Localidade { get; set; }

        [Required]
        [Column("uf")]
        public string Uf { get; set; }

        [Column("complemento")]
        public string Complemento { get; set; }


    }
}