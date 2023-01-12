using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ms_partnership.Models.Entities
{
    [Table("promo")]
    public class Promo
    {
        [Key]
        [Required]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("discount")]
        public double Discount { get; set; }

        [Required]
        [Column("condition")]
        public Boolean Condition { get; set; }

        [Column("discount_description")]
        public string? DiscountDescription { get; set; }

        [Column("start_date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime?  StartDate { get; set; }

        [Column("end_date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }
    }
}