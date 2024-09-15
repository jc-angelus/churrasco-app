using Churrasco.Infrastructure.Entities;
using AutoMapper;
using Churrasco.Domain.Models;

namespace Churrasco.Domain.Mappers
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 13/09/2024
    /// Class: DomainMappingProfile
    /// </summary
    public class DomainMappingProfile : Profile
    {
        public DomainMappingProfile()
        {   

            CreateMap<UserModel, User>().ReverseMap();

            CreateMap<ProductModel, Product>().ReverseMap();
        }
    }
}
