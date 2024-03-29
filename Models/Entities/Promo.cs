using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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

        [Column("created")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Created { get; set; } = DateTime.UtcNow;

        [Column("start_date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DefaultValue(null)]
        public DateTime? StartDate { get; set; } = null;

        [Column("end_date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DefaultValue(null)]
        public DateTime? EndDate { get; set; } = null;

        [Column("company_id")]
        public Guid CompanyId { get; set; }

        [JsonIgnore]
        public virtual Company Company { get; set; }
    }
}