using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ms_partnership.Models.Entities.Dtos.Review
{
    public class UpdateReviewDto
    {
        [Required(ErrorMessage = "Grade is required")]
        [Column("good_grade")]
        public Boolean GoodGrade { get; set; }

        [Required(ErrorMessage = "Grade is required")]
        [Column("bad_grade")]
        public Boolean BadGrade { get; set; }

        [Column("comentaries")]
        public string? Comentaries { get; set; }

        [Column("user_id")]
        [DefaultValue(null)]
        public Guid? UserId { get; set; } = null;

        [Column("company_id")]
        [DefaultValue(null)]
        public Guid? CompanyId { get; set; } = null;
    }
}