using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ms_partnership.Models.Entities
{
    [Table("user")]
    public class User
    {
        [Key]
        [Required]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("first_name")]
        public string FirstName { get; set; }

        [Required]
        [Column("last_name")]
        public string LastName { get; set; }

        [Required]
        [Column("cpf")]
        public string Cpf { get; set; }

        [Column("avatar_img")]
        public string? AvatarImg { get; set; }

        public virtual List<Login> Logins { get; set; }

        public virtual List<Review> Reviews { get; set; }
    }
}