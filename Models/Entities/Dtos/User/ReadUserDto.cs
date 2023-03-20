using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ms_partnership.Models.Entities.Dtos.User
{
    public class ReadUserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cpf { get; set; }
        public string? AvatarImg { get; set; }
        public bool Active { get; set; }

        public virtual Models.Entities.Address? Address { get; set; }
        public virtual Models.Entities.Login Login { get; set; }
        public virtual List<Models.Entities.Review>? Reviews { get; set; }
    }
}