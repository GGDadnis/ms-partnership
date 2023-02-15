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
        [Column("email")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Email need to have betewen 2 and 50 characters")]
        [Required(ErrorMessage = "Login need to have an valid email", AllowEmptyStrings = false)]
        public string Email { get; set; }

        [Column("password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Login need to have a password", AllowEmptyStrings = false)]
        public string Password { get; set; }
    }
}