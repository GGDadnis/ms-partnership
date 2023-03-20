using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ms_partnership.Models.Entities.Dtos.Company
{
    public class ReadCompanyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public string? LogoImg { get; set; }
        public double? TotalGrade { get; set; }
        public bool active { get; set; } = true;

        public virtual Models.Entities.Category? Category { get; set; }
        public virtual List<Models.Entities.Address>? Addresses { get; set; }
        public virtual List<Models.Entities.Login>? Logins { get; set; }
        public virtual List<Models.Entities.Promo>? Promos { get; set; }
        public virtual List<Models.Entities.Review>? Reviews { get; set; }
    }
}