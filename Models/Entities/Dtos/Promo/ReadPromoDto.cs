using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ms_partnership.Models.Entities.Dtos.Promo
{
    public class ReadPromoDto
    {
        public Guid Id { get; set; }
        public double Discount { get; set; }
        public Boolean Condition { get; set; }
        public string? DiscountDescription { get; set; }
        public DateTime Created { get; set; }
        public DateTime? StartDate { get; set; } = null;
        public DateTime? EndDate { get; set; } = null;
        public Guid CompanyId { get; set; }

        [JsonIgnore]
        public virtual Models.Entities.Company Company { get; set; }
    }
}