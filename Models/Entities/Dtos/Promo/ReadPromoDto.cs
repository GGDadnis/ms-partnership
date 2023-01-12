using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ms_partnership.Models.Entities.Dtos.Promo
{
    public class ReadPromoDto
    {
        [Required]
        [Column("id")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Discount is required")]
        [Column("discount")]
        public double Discount { get; set; }

        [Required(ErrorMessage = "Condition is required")]
        [Column("condition")]
        public Boolean Condition { get; set; }

        [Column("discount_description")]
        public string? DiscountDescription { get; set; }

        [Column("start_date")]
        public DateTime? StartDate { get; set; }

        [Column("end_date")]
        public DateTime? EndDate { get; set; }
    }
}