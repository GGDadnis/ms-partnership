using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    }
}