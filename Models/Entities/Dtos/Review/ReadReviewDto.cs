using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ms_partnership.Models.Entities.Dtos.Review
{
    public class ReadReviewDto
    {
        public Guid Id { get; set; }
        public Boolean GoodGrade { get; set; }
        public Boolean BadGrade { get; set; }
        public string? Comentaries { get; set; }

        [JsonIgnore]
        public virtual Models.Entities.User? User { get; set; }
        public Guid? UserId { get; set; } = null;
        public Guid? CompanyId { get; set; } = null;
    }
}