using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ms_partnership.Models.Entities.Dtos.Company
{
    public class UpdateCompanyDto
    {
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

        [Column("category_id")]
        public Guid CategoryId { get; set; }
    }
}