using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ms_partnership.Models.Entities.Dtos.Promo
{
    public class UpdatePromoDto
    {
        public double Discount { get; set; }
        public Boolean Condition { get; set; }
        public string? DiscountDescription { get; set; }
        public DateTime? StartDate { get; set; } = null;
        public DateTime? EndDate { get; set; } = null;
        public Guid CompanyId { get; set; }
    }
}