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
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public Boolean Professional { get; set; } = false;
        public string? salt { get; set; }
        public Guid? CompanyId { get; set; }

        [JsonIgnore]
        public virtual Models.Entities.Company? Company { get; set; }
        public Guid? UserId { get; set; }
        [JsonIgnore]
        public virtual Models.Entities.User? User { get; set; }
    }
}