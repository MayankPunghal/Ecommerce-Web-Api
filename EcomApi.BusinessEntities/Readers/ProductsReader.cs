using EcomApi.BusinessEntities.ResponseProxies;
using EcomApi.DataEntities;
using EcomApi.DataEntities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace EcomApi.BusinessEntities.Readers
{
    public class ProductsReader
    {
        EcomContext Context = new EcomContext();
        public List<Products> GetProductsList()
        {
            List<Products> users = new List<Products>();
            users = (from p in Context.Products.AsNoTracking()
                     select p).ToList();
            return users;

        }
        public List<Categories> GetCategoriesList()
        {
            List<Categories> category = new List<Categories>();
            category = (from c in Context.Categories.AsNoTracking()
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
        public bool CheckIfProductExistByName(string ProductName)
        {
            bool check = false;
            check = (from p in Context.Products.AsNoTracking()
                     where p.ProductName == ProductName
                     select true).FirstOrDefault();
            return check;
        }
        public bool CheckIfCategoryExistByName(string CategoryName)
        {
            bool check = false;
            check = (from c in Context.Categories
                     where c.CategoryName == CategoryName
                     select true).FirstOrDefault();
            return check;
        }
        public bool CheckIfCategoryExistById(int CategoryId)
        {
            bool check = false;
            check = (from c in Context.Categories
                     where c.CategoryId == CategoryId
                     select true).FirstOrDefault();
            return check;
        }
        public bool CheckIfProductNameIsChanged(string ProductName, int ProductId)
        {
            bool check = false;
            check = (from p in Context.Products
                     where p.ProductID == ProductId
                     select p.ProductName != ProductName).FirstOrDefault();
            return check;
        }
        public bool CheckIfCategoryNameIsChanged(string CategoryName, int CategoryId)
        {
            bool check = false;
            check = (from c in Context.Categories
                     where c.CategoryId == CategoryId
                     select c.CategoryName != CategoryName).FirstOrDefault();
            return check;
        }
        public bool CheckIfProductExistById(int ProductId)
        {
            bool check = false;
            check = (from p in Context.Products
                     where p.ProductID == ProductId
                     select true).FirstOrDefault();
            return check;
        }
    }
}
