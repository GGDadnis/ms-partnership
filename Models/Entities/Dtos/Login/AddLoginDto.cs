using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ms_partnership.Models.Entities.Dtos.Login
{
    public class AddLoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public Boolean Professional { get; set; } = false;
        public Guid? CompanyId { get; set; } = null;
        public Guid? UserId { get; set; } = null;
    }
}