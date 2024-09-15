using Churrasco.Infrastructure.Entities;
using Churrasco.Infrastructure.Repositories.Generic;
using Churrasco.Infrastructure.Repositories.Interfaces.Entities;
using Churrasco.Infrastructure.Repositories.Interfaces.Generic;

namespace Churrasco.Infrastructure.Repositories.Entities
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 13/09/2024
    /// Class: ProductsRepository
    /// </summary>
    public class ProductsRepository : GenericRepository<Product>, IProductsRepository
    {
        public ProductsRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
