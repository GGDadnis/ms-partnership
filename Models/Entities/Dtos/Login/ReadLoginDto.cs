using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ms_partnership.Models.Entities.Dtos.Login
{
    public class ReadLoginDto
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
        [Required(ErrorMessage = "Login need to have a password", AllowEmptyStrings = false)]
        public string Password { get; set; }

        [Column("role")]
        public string Role { get; set; }

        [Required]
        [Column("professional")]
        public Boolean Professional { get; set; } = false;

        [Column("company_id")]
        public Guid? CompanyId { get; set; }

        [JsonIgnore]
        public virtual Models.Entities.Company? Company { get; set; }

        [Column("user_id")]
        public Guid? UserId { get; set; }

        [JsonIgnore]
        public virtual Models.Entities.User? User { get; set; }
    }
}