using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ms_partnership.Models.Entities.Dtos.Review
{
    public class ReadReviewDto
    {
        [Required]
        [Column("id")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Grade is required")]
        [Column("good_grade")]
        public Boolean GoodGrade { get; set; }

        [Required(ErrorMessage = "Grade is required")]
        [Column("bad_grade")]
        public Boolean BadGrade { get; set; }

        [Column("comentaries")]
        public string? Comentaries { get; set; }
    }
}