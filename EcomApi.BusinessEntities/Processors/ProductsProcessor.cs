using EcomApi.BusinessEntities.Readers;
using EcomApi.BusinessEntities.RequestProxies;
using EcomApi.BusinessEntities.ResponseProxies;
using EcomApi.BusinessEntities.Writers;
using EcomApi.DataEntities.Models;
using EcomApi.Utils.Common;

namespace EcomApi.BusinessEntities.Processors
{
    public class ProductsProcessor
    {
        private DateTime DtNow { get; set; }


        ProductsReader reader = new ProductsReader();
        ProductsWriter writer = new ProductsWriter();

        public ProductsProcessor()
        {
            DtNow = DateTime.UtcNow;
        }

        public GetProductResponseProxy GetProductsData(GetProductRequestProxy req)
        {
            Log.Info($"GetProductsData Method call started @{DateTime.UtcNow:O}");
            GetProductResponseProxy response = new GetProductResponseProxy();
            try
            {
                response.ProductList = reader.GetProductsList();

                response.status = 1;
                response.message = "Product List Got Successfully";
            }
            catch (Exception ex)
            {
                Log.Error($"Error in GetProductsData : {ex}");
            }
            finally
            {
                Log.Info($"GetProductsData Method call ended @{DateTime.UtcNow:O}");
                response.responseTime = DateTime.UtcNow;
            }
            return response;
        }
        public GetCategoryResponseProxy GetCategoriesData(GetCategoryRequestProxy req)
        {
            Log.Info($"GetCategory Method call started @{DateTime.UtcNow:O}");
            GetCategoryResponseProxy response = new GetCategoryResponseProxy();
            try
            {
                response.CategoryList = reader.GetCategoriesList();

                response.status = 1;
                response.message = "Product List Got Successfully";
            }
            catch (Exception ex)
            {
                Log.Error($"Error in GetCategory : {ex}");
            }
            finally
            {
                Log.Info($"GetCategory Method call ended @{DateTime.UtcNow:O}");
                response.responseTime = DateTime.UtcNow;
            }
            return response;
        }
        public GetProductByIdResponseProxy GetProductDataById(GetProductByIdRequestProxy req)
        {
            Log.Info($"GetProductDataById Method call started @{DateTime.UtcNow:O}");
            GetProductByIdResponseProxy response = new GetProductByIdResponseProxy();
            try
            {
                response.ProductData = reader.GetProductById(req.ProductId);

                response.status = 1;
                response.message = $"Product Data Got Successfully for ProductId : {req.ProductId}";
            }
            catch (Exception ex)
            {
                Log.Error($"Error in GetProductDataById : {ex}");
            }
            finally
            {
                Log.Info($"GetProductDataById Method call ended @{DateTime.UtcNow:O}");
                response.responseTime = DateTime.UtcNow;
            }
            return response;
        }
        public SetProductResponseProxy SetProduct(SetProductRequestProxy req)
        {
            Log.Info($"SetProduct Method call started @{DateTime.UtcNow:O}");
            SetProductResponseProxy response = new SetProductResponseProxy();
            try
            {
                //check if user already exist based on UserName and Email
                if (!reader.CheckIfProductExistByName(req.ProductName))
                {
                    Products product = new Products();
                    product.ProductName = req.ProductName;
                    product.Price = req.Price;
                    product.Description = req.Description;
                    product.IsActive = true;
                    product.ImageName = req.ImageName;
                    product.StockQuantity = req.StockQuantity;
                    product.CategoryId = req.CategoryId;

                    writer.SetProduct(product);

                }
                else
                {
                    response.status = 0;
                    response.message = $"Product with name {req.ProductName} already exists !";
                }
                response.status = 1;
                response.message = $"Product Got Successfully Created for Product Name : {req.ProductName}";
            }
            catch (Exception ex)
            {
                Log.Error($"Error in SetProduct : {ex}");
            }
            finally
            {
                Log.Info($"SetProduct Method call ended @{DateTime.UtcNow:O}");
                response.responseTime = DateTime.UtcNow;
            }
            return response;
        }

        public SetCategoryResponseProxy SetCategory(SetCategoryRequestProxy req)
        {
            Log.Info($"SetCategory Method call started @{DateTime.UtcNow:O}");
            SetCategoryResponseProxy response = new SetCategoryResponseProxy();
            try
            {
                //check if user already exist based on UserName and Email
                if (!reader.CheckIfCategoryExistByName(req.CategoryName))
                {
                    Categories category = new Categories();
                    category.CategoryName = req.CategoryName;
                    category.CategoryDescription = req.CategoryDescription;
                    writer.SetCategory(category);
                    response.status = 1;
                    response.message = $"Category Got Successfully Created for Category Name : {req.CategoryName}";
                }
                else
                {
                    response.status = 0;
                    response.message = $"Category with name {req.CategoryName} already exists !";
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Error in SetCategory : {ex}");
            }
            finally
            {
                Log.Info($"SetCategory Method call ended @{DateTime.UtcNow:O}");
                response.responseTime = DateTime.UtcNow;
            }
            return response;
        }
        public DeleteCategoryResponseProxy DeleteCategory(DeleteCategoryRequestProxy req)
        {
            Log.Info($"DeleteCategory Method call started @{DateTime.UtcNow:O}");
            DeleteCategoryResponseProxy response = new DeleteCategoryResponseProxy();
            try
            {
                //check if user already exist based on UserName and Email
                if (reader.CheckIfCategoryExistById(req.CategoryId))
                {
                    writer.DeleteCategory(req.CategoryId);
                    response.status = 1;
                    response.message = $"Category Got Successfully Deleted for Category Id : {req.CategoryId}";
                }
                else
                {
                    response.status = 0;
                    response.message = $"Category with Id : {req.CategoryId} does not exist";
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Error in DeleteCategory : {ex}");
            }
            finally
            {
                Log.Info($"DeleteCategory Method call ended @{DateTime.UtcNow:O}");
                response.responseTime = DateTime.UtcNow;
            }
            return response;
        }

        public UpdateCategoryResponseProxy UpdateCategory(UpdateCategoryRequestProxy req)
        {
            Log.Info($"UpdateCategory Method call started @{DateTime.UtcNow:O}");
            UpdateCategoryResponseProxy response = new UpdateCategoryResponseProxy();
            try
            {
                if (reader.CheckIfProductNameIsChanged(req.CategoryName, req.CategoryId))
                    if (!reader.CheckIfProductExistByName(req.CategoryName))
                    {
                        Categories category = new Categories();
                        category.CategoryId = req.CategoryId;
                        category.CategoryName = req.CategoryName;
                        category.CategoryDescription = req.CategoryDescription;
                        writer.UpdateCategory(category);
                        response.status = 1;
                        response.message = $"Category Got Successfully Updated with Category Name : {req.CategoryName}";
                    }
                    else
                    {
                        response.status = 0;
                        response.message = $"Category with name {req.CategoryName} already exists !";
                    }
                else
                {
                    Categories category = new Categories();
                    category.CategoryId = req.CategoryId;
                    category.CategoryName = req.CategoryName;
                    category.CategoryDescription = req.CategoryDescription;
                    writer.UpdateCategory(category);
                    response.status = 1;
                    response.message = $"Category Got Successfully Updated with Category Name : {req.CategoryName}";
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Error in UpdateCategory : {ex}");
            }
            finally
            {
                Log.Info($"UpdateCategory Method call ended @{DateTime.UtcNow:O}");
                response.responseTime = DateTime.UtcNow;
            }
            return response;
        }
        public UpdateProductResponseProxy UpdateProduct(UpdateProductRequestProxy req)
        {
            Log.Info($"UpdateProduct Method call started @{DateTime.UtcNow:O}");
            UpdateProductResponseProxy response = new UpdateProductResponseProxy();
            try
            {
                if (reader.CheckIfProductNameIsChanged(req.ProductName, req.ProductID))
                    if (!reader.CheckIfProductExistByName(req.ProductName))
                    {
                        Products product = new Products();
                        product.ProductID = req.ProductID;
                        product.ProductName = req.ProductName;
                        product.Description = req.Description;
                        product.Price = req.Price;
                        product.CategoryId = req.CategoryId;
                        product.StockQuantity = req.StockQuantity;
                        product.ImageName = req.ImageName;
                        product.IsActive = req.IsActive;
                        writer.UpdateProduct(product);
                        response.status = 1;
                        response.message = $"Category Got Successfully Updated with Product Name : {req.ProductName}";
                    }
                    else
                    {
                        response.status = 0;
                        response.message = $"Product with name {req.ProductName} already exists !";
                    }
                else
                {
                    Products product = new Products();
                    product.ProductID = req.ProductID;
                    product.ProductName = req.ProductName;
                    product.Description = req.Description;
                    product.Price = req.Price;
                    product.CategoryId = req.CategoryId;
                    product.StockQuantity = req.StockQuantity;
                    product.ImageName = req.ImageName;
                    product.IsActive = req.IsActive;
                    writer.UpdateProduct(product);
                    response.status = 1;
                    response.message = $"Category Got Successfully Updated with Product Name : {req.ProductName}";
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Error in UpdateProduct : {ex}");
            }
            finally
            {
                Log.Info($"UpdateProduct Method call ended @{DateTime.UtcNow:O}");
                response.responseTime = DateTime.UtcNow;
            }
            return response;
        }

        public DeleteCategoryResponseProxy DeleteProduct(DeletProductRequestProxy req)
        {
            Log.Info($"DeleteProduct Method call started @{DateTime.UtcNow:O}");
            DeleteCategoryResponseProxy response = new DeleteCategoryResponseProxy();
            try
            {
                //check if user already exist based on UserName and Email
                if (reader.CheckIfProductExistById(req.ProductId))
                {
                    writer.DeleteProduct(req.ProductId);
                    response.status = 1;
                    response.message = $"Product Got Successfully Deleted for Product Id : {req.ProductId}";
                }
                else
                {
                    response.status = 0;
                    response.message = $"Product with Id : {req.ProductId} does not exist";
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Error in DeleteProduct : {ex}");
            }
            finally
            {
                Log.Info($"DeleteProduct Method call ended @{DateTime.UtcNow:O}");
                response.responseTime = DateTime.UtcNow;
            }
            return response;
        }

    }
}
