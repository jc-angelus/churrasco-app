
using Churrasco.Infrastructure.Entities;

namespace Churrasco.Application.Interfaces
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 13/09/2024
    /// Interface: ILoginServices
    /// </summary>
    public interface ILoginServices
    {
        Task<User> Login(string email, string password);        
    }
}
