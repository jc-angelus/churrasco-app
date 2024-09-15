using Churrasco.Domain.Models;

namespace Churrasco.Application.Interfaces
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 13/09/2024
    /// Interface: IProductServices
    /// </summary>
    public interface IProductsServices
    {
        Task<uint> CreateProductAsync(ProductModel productModel);
        Task<ProductModel> ReadProductAsync(uint id);
        Task<ProductModel> UpdateProductAsync(ProductModel productModel);
        Task<bool> DeleteProductAsync(uint id);
        Task<List<ProductModel>> ProductListAsync();
    }
}
