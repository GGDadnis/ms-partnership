using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ms_partnership.Models.Entities.Dtos.Promo
{
    public class UpdatePromoDto
    {
        [Required(ErrorMessage = "Discount is required")]
        [Column("discount")]
        public double Discount { get; set; }

        [Required(ErrorMessage = "Condition is required")]
        [Column("condition")]
        public Boolean Condition { get; set; }

        [Column("discount_description")]
        public string? DiscountDescription { get; set; }

        [Column("start_date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Column("end_date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [Column("company_id")]
        public Guid CompanyId { get; set; }
    }
}