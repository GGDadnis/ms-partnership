using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ms_partnership.Models.Entities.Dtos.Company
{
    public class AddCompanyDto
    {
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public string? LogoImg { get; set; }
        public double? TotalGrade { get; set; }
        public Guid CategoryId { get; set; }
    }
}