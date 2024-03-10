using EcomApi.BusinessEntities.Processors;
using EcomApi.BusinessEntities.RequestProxies;
using EcomApi.Helpers;
using EcomApi.Utils.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcomApi.Controllers
{
    public class ProductsController : ControllerBase
    {
        [Route(ApiRoute.products.getproducts)]
        [HttpPost]
        public IActionResult GetProducts([FromBody] GetProductRequestProxy requestproxy)
        {
            Log.Info($"{requestproxy.UserData.UserId} requested the list of Products");
            var productPro = new ProductsProcessor();
            var data = productPro.GetProductsData(requestproxy);
            return Ok(data);
        }
        [Route(ApiRoute.products.getcategories)]
        [HttpPost]
        public IActionResult GetCategories([FromBody] GetCategoryRequestProxy requestproxy)
        {
            Log.Info($"{requestproxy.UserData.UserId} requested the list of Categories");
            var productPro = new ProductsProcessor();
            var data = productPro.GetCategoriesData(requestproxy);
            return Ok(data);
        }
        [Route(ApiRoute.products.getproductbyid)]
        [HttpPost]
        public IActionResult GetUserById([FromBody] GetProductByIdRequestProxy requestproxy)
        {
            Log.Info($"{requestproxy.UserData.UserId} requested product data for Product ID : {requestproxy.ProductId}");
            var productPro = new ProductsProcessor();
            var data = productPro.GetProductDataById(requestproxy);
            return Ok(data);
        }
        [Route(ApiRoute.products.setproduct)]
        [HttpPost]
        public IActionResult SetPoduct([FromBody] SetProductRequestProxy requestproxy)
        {
            Log.Info($"Creating product data for Product Name : {requestproxy.ProductName}");
            var productPro = new ProductsProcessor();
            var data = productPro.SetProduct(requestproxy);
            return Ok(data);
        }
        [Route(ApiRoute.products.setcategory)]
        [HttpPost]
        public IActionResult SetCategory([FromBody] SetCategoryRequestProxy requestproxy)
        {
            Log.Info($"Creating category data for Category Name : {requestproxy.CategoryName}");
            var productPro = new ProductsProcessor();
            var data = productPro.SetCategory(requestproxy);
            return Ok(data);
        }
        //[Authorize(Roles = "Admin")]
        [Authorize(Policy = "RequireAdministratorRole")]
        [Route(ApiRoute.products.deletecategory)]
        [HttpPost]
        public IActionResult DeleteCategory([FromBody] DeleteCategoryRequestProxy requestproxy)
        {
            Log.Info($"Deleting category data for Category Id : {requestproxy.CategoryId}");
            var productPro = new ProductsProcessor();
            var data = productPro.DeleteCategory(requestproxy);
            return Ok(data);
        }
        [Route(ApiRoute.products.updatecategory)]
        [HttpPost]
        public IActionResult UpdateCategory([FromBody] UpdateCategoryRequestProxy requestproxy)
        {
            Log.Info($"Updating category data for Category Id : {requestproxy.CategoryId}");
            var productPro = new ProductsProcessor();
            var data = productPro.UpdateCategory(requestproxy);
            return Ok(data);
        }
        [Route(ApiRoute.products.updateproduct)]
        [HttpPost]
        public IActionResult UpdateProduct([FromBody] UpdateProductRequestProxy requestproxy)
        {
            Log.Info($"Updating Product data for Product Id : {requestproxy.ProductID}");
            var productPro = new ProductsProcessor();
            var data = productPro.UpdateProduct(requestproxy);
            return Ok(data);
        }
        [Route(ApiRoute.products.deleteproduct)]
        [HttpPost]
        public IActionResult DeleteProduct([FromBody] DeletProductRequestProxy requestproxy)
        {
            Log.Info($"Deleting Product data for ProductId Id : {requestproxy.ProductId}");
            var productPro = new ProductsProcessor();
            var data = productPro.DeleteProduct(requestproxy);
            return Ok(data);
        }
    }
}
