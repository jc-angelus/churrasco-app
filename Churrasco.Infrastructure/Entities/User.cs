
namespace Churrasco.Infrastructure.Entities { 

public partial class User {
    public uint Id { get; set; }

    public DateTime? Created { get; set; }

    public string? Email { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Password { get; set; }

    public DateTime? Updated { get; set; }

    public string? Username { get; set; }

    public string? Role { get; set; }

    public bool? Active { get; set; }    
    
    }

}