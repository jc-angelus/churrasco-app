using Churrasco.Application.Interfaces;
using Churrasco.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Churrasco.Presentation.Controllers
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 13/09/2024
    /// Class: ProductsController
    /// </summary>

    [Authorize]
    public class ProductsController : Controller
    {
               
        public readonly IProductsServices _productsServices;
        public ProductsController(IProductsServices productsServices)
        {            
            _productsServices = productsServices;
        }

        public async Task<IActionResult> Index()
        {
            var listProducts = await _productsServices.ProductListAsync();            
            ViewBag.BreadCrumbFirstItem = "Products";
            ViewBag.BreadCrumbSecondItem = "List Products";
            return View(listProducts.OrderByDescending(x => x.Id));           
            
        }

        public async Task<IActionResult> Create()
        {            
            var productModel = new ProductModel();
            ViewBag.BreadCrumbFirstItem = "Products";
            ViewBag.BreadCrumbSecondItem = "Create Product";
            return View(productModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductModel productModel, IFormFile singleFile)
        {

            if (singleFile == null)
            {
                ModelState.AddModelError("", "Please add the product image");                
                return View("Create", productModel);
            }

            string imgRoute = "~/dist/img/" + singleFile.FileName;
            productModel.Picture = imgRoute;

            uint? idProduct = null;

            try
            {
                idProduct = await _productsServices.CreateProductAsync(productModel);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "An error has occurred, please check");
                return View("Create", productModel);

            }            

            if(idProduct != null)
            { 
                var filePath = Path.Combine("wwwroot/dist/img/", singleFile.FileName);
                using (var stream = System.IO.File.Create(filePath))
                {
                    await singleFile.CopyToAsync(stream);
                }
            }
            else
            {
                ModelState.AddModelError("", "An error has occurred, please check");
                return View("Create", productModel);
            }               
            
            
            var listProducts = await _productsServices.ProductListAsync();
            ViewBag.BreadCrumbFirstItem = "Products";
            ViewBag.BreadCrumbSecondItem = "List Products";
            return View("Index", listProducts.OrderByDescending(x => x.Id));
        }

        public async Task<IActionResult> Details(uint id)
        {
            var productModel = await _productsServices.ReadProductAsync(id);            
            ViewBag.BreadCrumbFirstItem = "Products";
            ViewBag.BreadCrumbSecondItem = "Detail Product";            
            return View(productModel);
        }

        public async Task<IActionResult> Edit(uint id)
        {
            var productModel = await _productsServices.ReadProductAsync(id);
            ViewBag.BreadCrumbFirstItem = "Product";
            ViewBag.BreadCrumbSecondItem = "Edit Product";
            return View("Edit", productModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductModel productModel, IFormFile singleFile)
        {

            string fileName = string.Empty;


            if (singleFile != null)
            {
                string imgRoute = "~/dist/img/" + singleFile.FileName;
                productModel.Picture = imgRoute;
            }

            try
            {
                await _productsServices.UpdateProductAsync(productModel);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "An error has occurred, please check");
                return View("Edit", productModel);
            }           
            

            if (singleFile != null)
            {
                var filePath = Path.Combine("wwwroot/dist/img/", singleFile.FileName);
                using (var stream = System.IO.File.Create(filePath))
                {
                    await singleFile.CopyToAsync(stream);
                }
            }
            

            var listProducts = await _productsServices.ProductListAsync();
            ViewBag.BreadCrumbFirstItem = "Product";
            ViewBag.BreadCrumbSecondItem = "Edit Product";
            return View("Index", listProducts.OrderByDescending(x => x.Id));
        }

        public async Task<IActionResult> Delete(uint id)
        {

            var productModel = await _productsServices.ReadProductAsync(id);

            await _productsServices.DeleteProductAsync(id);

            if (productModel != null) { 

                string fileRoute = "wwwroot" + productModel.Picture.Replace("~", string.Empty);                

                if (System.IO.File.Exists(fileRoute))
                {
                    System.IO.File.Delete(fileRoute);
                }
            }

            var listProducts = await _productsServices.ProductListAsync();
            ViewBag.BreadCrumbFirstItem = "Product";
            ViewBag.BreadCrumbSecondItem = "List Product";
            return View("Index", listProducts.OrderByDescending(x => x.Id));            

        }

    }
}
