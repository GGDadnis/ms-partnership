using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace ms_partnership.Models.Entities
{
    public class Login
    {
        [Key]
        [Required]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("email")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Email need to have betewen 2 and 50 characters")]
        [Required(ErrorMessage = "Login need to have an valid email", AllowEmptyStrings = false)]
        public string Email { get; set; }

        [Column("password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Column("role")]
        public string Role { get; set; }

        [Required]
        [Column("professional")]
        [DefaultValue(false)]
        public Boolean Professional { get; set; } = false;

        [Column("company_id")]
        [DefaultValue(null)]
        public Guid? CompanyId { get; set; } = null;

        [JsonIgnore]
        public virtual Company? Company { get; set; }

        [ForeignKey("User")]
        [Column("user_id")]
        [DefaultValue(null)]
        public Guid? UserId { get; set; } = null;

        [JsonIgnore]
        public virtual User? User { get; set; }
    }
}