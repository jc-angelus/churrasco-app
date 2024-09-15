using AutoMapper;
using Churrasco.Application.Interfaces;
using Churrasco.Domain.Models;
using Churrasco.Infrastructure.Entities;
using Churrasco.Infrastructure.Repositories.Interfaces.Entities;
using System.Linq.Expressions;

namespace Churrasco.Application.Services
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 13/09/2024
    /// Class: LoginServices
    /// </summary>
    public class LoginServices : ILoginServices
    {
        
        private readonly IUserRepository _repositoryUser;
        private readonly IMapper _mapper;

        public LoginServices(IUserRepository repositoryUser, IMapper mapper)
        {            
            _repositoryUser = repositoryUser;
            _mapper = mapper;

        }

        public async Task<User> Login(string email, string password)
        {

            Expression<Func<User, bool>> criteria = p => (p.Email == email || p.Username == email) && p.Password == password && p.Role.ToUpper() == "ADMIN" && p.Active == true ;

            var userEntity = _repositoryUser.ReadByConditionAsync(criteria);

            var userModel = _mapper.Map<UserModel>(userEntity);

            return userEntity;            
        }       

       
    }
}
