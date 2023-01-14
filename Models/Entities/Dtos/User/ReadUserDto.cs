using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ms_partnership.Models.Entities.Dtos.User
{
    public class ReadUserDto
    {
        [Required]
        [Column("id")]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="First name is required")]
        [Column("first_name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Last name is required")]
        [Column("last_name")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Valid cpf is required")]
        [Column("cpf")]
        public string Cpf { get; set; }

        [Column("avatar_img")]
        public string? AvatarImg { get; set; }

        public virtual Models.Entities.Address? Address { get; set; }
        public virtual Models.Entities.Login Login { get; set; }
        public virtual List<Models.Entities.Review>? Reviews { get; set; }
    }
}