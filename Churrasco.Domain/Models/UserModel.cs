using System.ComponentModel.DataAnnotations;

namespace Churrasco.Domain.Models
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 13/09/2024
    /// Class: UserModel
    /// </summary
    public class UserModel
    {   
        public uint Id { get; set; }

        public DateTime? Created { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public DateTime? Updated { get; set; }

        public string? Username { get; set; }

        public string? Role { get; set; }

        public bool? Active { get; set; }
    }
}
