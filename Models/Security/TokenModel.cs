using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ms_partnership.Models.Security
{
    public class TokenModel
    {
        public string? Token { get; set; }
        public DateTime? ValidTo { get; set; }
    }
}