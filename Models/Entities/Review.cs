using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ms_partnership.Models.Entities
{
    [Table("Review")]
    public class Review
    {
        [Key]
        [Required]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("good_grade")]
        public Boolean GoodGrade { get; set; }

        [Required]
        [Column("bad_grade")]
        public Boolean BadGrade { get; set; }

        [Column("comentaries")]
        public string? Comentaries { get; set; }

        [Column("user_id")]
        [DefaultValue(null)]
        public Guid? UserId { get; set; } = null;

        [JsonIgnore]
        public virtual User? User { get; set; }

        [Column("company_id")]
        [DefaultValue(null)]
        public Guid? CompanyId { get; set; } = null;

        [JsonIgnore]
        public virtual Company? Company { get; set; }

    }
}