using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ms_partnership.Models.Entities
{
    public class Login
    {
        [Key]
        [Required]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("user_name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Username need to have betewen 2 and 50 characters")]
        public string Username { get; set; }

        [Column("password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Column("professional")]
        public Boolean Professional { get; set; } = false;

        // [Column("acess_type")]
        // [Required(ErrorMessage = "User need to have an acess type")]
        // public UserRoles? AcessType { get; set; }

    }
}