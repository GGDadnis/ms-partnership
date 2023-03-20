using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ms_partnership.Models.Entities.Dtos.Review
{
    public class UpdateReviewDto
    {
        public Boolean GoodGrade { get; set; }
        public Boolean BadGrade { get; set; }
        public string? Comentaries { get; set; }
        public Guid? UserId { get; set; } = null;
        public Guid? CompanyId { get; set; } = null;
    }
}