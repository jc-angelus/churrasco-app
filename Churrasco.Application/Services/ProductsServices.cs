
using AutoMapper;
using Churrasco.Domain.Models;
using Churrasco.Application.Interfaces;
using Churrasco.Infrastructure.Entities;
using Churrasco.Infrastructure.Repositories.Interfaces.Entities;

namespace Churrasco.Application.Services
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 13/09/2024
    /// Class: ProductServices
    /// </summary>
    public class ProductsServices : IProductsServices
    {

        private readonly IProductsRepository _repositoryProducts;
        private readonly IMapper _mapper;

        public ProductsServices(IProductsRepository repositoryProducts, IMapper mapper)
        {
            _repositoryProducts = repositoryProducts;
            _mapper = mapper;
        }

        public async Task<uint> CreateProductAsync(ProductModel productModel)
        {

            var productEntity = _mapper.Map<Product>(productModel);

            productEntity = await _repositoryProducts.CreateAsync(productEntity);

            return productEntity.Id;
        }

        public async Task<ProductModel> ReadProductAsync(uint id)
        {
            var productEntity = await _repositoryProducts.ReadAsync(id);

            var productModel = _mapper.Map<ProductModel>(productEntity);

            return productModel;
        }


        public async Task<ProductModel> UpdateProductAsync(ProductModel productModel)
        {            

            if (productModel.Picture == null)
            {
                uint idProduct = productModel.Id;

                var productImage = await _repositoryProducts.ReadAsync(idProduct);

                productModel.Picture = productImage.Picture;
            }

            var productEntity = _mapper.Map<Product>(productModel);

            productEntity = await _repositoryProducts.UpdateAsync(productEntity, productEntity.Id);

            productModel = _mapper.Map<ProductModel>(productEntity);

            return productModel;
        }

        public async Task<bool> DeleteProductAsync(uint id)
        {
            return await _repositoryProducts.DeleteAsync(id);
        }


        public async Task<List<ProductModel>> ProductListAsync()
        {

            var productListEntities = await _repositoryProducts.ListAsync();

            var productListModel = _mapper.Map<List<ProductModel>>(productListEntities);

            return productListModel;

        }
        
    }
}
