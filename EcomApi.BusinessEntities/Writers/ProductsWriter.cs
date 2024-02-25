using EcomApi.DataEntities.Models;
using EcomApi.Utils;
using EcomApi.Utils.Common;
using Microsoft.EntityFrameworkCore;


namespace EcomApi.BusinessEntities.Writers
{
    public class ProductsWriter
    {
        EcomContext Context = new EcomContext();
        public void SetProduct(Products p)
        {
            Context.Products.Add(p);
            Context.SaveChanges();
        }
        public void SetCategory(Categories c)
        {
            Context.Categories.Add(c);
            Context.SaveChanges();
        }
        public void UpdateCategory(Categories c)
        {
            Context.Categories.UpdateRange(c);
            Context.SaveChanges();
        }
        public void DeleteCategory(int CategoryId)
        {
            Context.Categories.Where(a => a.CategoryId == CategoryId).ExecuteDelete();
        }
    }
}
