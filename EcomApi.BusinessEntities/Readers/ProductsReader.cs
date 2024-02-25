using EcomApi.BusinessEntities.ResponseProxies;
using EcomApi.DataEntities;
using EcomApi.DataEntities.Models;
using Microsoft.IdentityModel.Tokens;

namespace EcomApi.BusinessEntities.Readers
{
    public class ProductsReader
    {
        EcomContext Context = new EcomContext();
        public List<Products> GetProductsList()
        {
            List<Products> users = new List<Products>();
            users = (from p in Context.Products
                     select p).ToList();
            return users;

        }
        public List<Categories> GetCategoriesList()
        {
            List<Categories> category = new List<Categories>();
            category = (from c in Context.Categories
                        select c).ToList();
            return category;
        }
        public Products GetProductById(int ProductId)
        {
            Products users = new Products();
            users = (from p in Context.Products
                     where p.ProductID == ProductId
                     select p).FirstOrDefault();
            return users;

        }
        public bool CheckIfProductExist(string ProductName)
        {
            bool check = false;
            check = (from p in Context.Products
                     where p.ProductName == ProductName
                     select true).FirstOrDefault();
            return check;
        }
        public bool CheckIfCategoryExistByName(string CategoryName)
        {
            bool check = false;
            check = (from p in Context.Categories
                     where p.CategoryName == CategoryName
                     select true).FirstOrDefault();
            return check;
        }
        public bool CheckIfCategoryExistById(int CategoryId)
        {
            bool check = false;
            check = (from p in Context.Categories
                     where p.CategoryId == CategoryId
                     select true).FirstOrDefault();
            return check;
        }
    }
}
