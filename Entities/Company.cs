using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ms_partnership.Models.Entities
{
    [Table("company")]
    public class Company
    {
        [Key]
        [Required]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [Column("cnpj")]
        public string Cnpj { get; set; }

        [Column("logo_img")]
        public string? LogoImg { get; set; }

        [Column("total_grade")]
        public double? TotalGrade { get; set; }
    }
}