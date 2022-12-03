using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ms_partnership.Models.Entities.Dtos.User
{
    public class UpdateUserDto
    {
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
    }
}