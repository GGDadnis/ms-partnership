using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ms_partnership.Models.Entities.Dtos.Company
{
    public class ReadCompanyDto
    {
        [Required]
        [Column("id")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Column("name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Cpnj is required")]
        [Column("cnpj")]
        public string Cnpj { get; set; }

        [Column("logo_img")]
        public string? LogoImg { get; set; }

        [Column("total_grade")]
        public double? TotalGrade { get; set; }

        public virtual List<Models.Entities.Login> Logins { get; set; }
    }
}