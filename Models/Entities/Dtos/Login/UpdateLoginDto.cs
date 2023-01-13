using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ms_partnership.Models.Entities.Dtos.Login
{
    public class UpdateLoginDto
    {
        [Column("username")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Username need to have betewen 2 and 50 characters")]
        [Required(ErrorMessage = "Login need to have an username", AllowEmptyStrings = false)]
        public string Username { get; set; }

        [Column("password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Login need to have a password", AllowEmptyStrings = false)]
        public string Password { get; set; }

        [Required]
        [Column("professional")]
        public Boolean Professional { get; set; } = false;

        [Column("company_id")]
        [DefaultValue(null)]
        public Guid? CompanyId { get; set; } = null;

        [Column("user_id")]
        [DefaultValue(null)]
        public Guid? UserId { get; set; } = null;
    }
}