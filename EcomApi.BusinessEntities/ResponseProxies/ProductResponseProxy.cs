using EcomApi.DataEntities.Models;

namespace EcomApi.BusinessEntities.ResponseProxies
{
    public class GetProductResponseProxy
    {
        public GetProductResponseProxy()
        {
            status = 0;
            requestTime = DateTime.UtcNow;
        }
        public int status { get; set; }
        public string message { get; set; }
        public DateTime requestTime { get; set; }
        public DateTime responseTime { get; set; }

        public List<Products> ProductList { get; set; }
    }
    public class GetCategoryResponseProxy
    {
        public GetCategoryResponseProxy()
        {
            status = 0;
            requestTime = DateTime.UtcNow;
        }
        public int status { get; set; }
        public string message { get; set; }
        public DateTime requestTime { get; set; }
        public DateTime responseTime { get; set; }

        public List<Categories> CategoryList { get; set; }
    }
    public class GetProductByIdResponseProxy
    {
        public GetProductByIdResponseProxy()
        {
            status = 0;
            requestTime = DateTime.UtcNow;
        }
        public int status { get; set; }
        public string message { get; set; }
        public DateTime requestTime { get; set; }
        public DateTime responseTime { get; set; }

        public Products ProductData { get; set; }
    }
    public class SetProductResponseProxy
    {
        public SetProductResponseProxy()
        {
            status = 0;
            requestTime = DateTime.UtcNow;
        }
        public int status { get; set; }
        public string message { get; set; }
        public DateTime requestTime { get; set; }
        public DateTime responseTime { get; set; }
    }
    public class SetCategoryResponseProxy
    {
        public SetCategoryResponseProxy()
        {
            status = 0;
            requestTime = DateTime.UtcNow;
        }
        public int status { get; set; }
        public string message { get; set; }
        public DateTime requestTime { get; set; }
        public DateTime responseTime { get; set; }
    }
    public class DeleteCategoryResponseProxy
    {
        public DeleteCategoryResponseProxy()
        {
            status = 0;
            requestTime = DateTime.UtcNow;
        }
        public int status { get; set; }
        public string message { get; set; }
        public DateTime requestTime { get; set; }
        public DateTime responseTime { get; set; }
    }
    public class UpdateCategoryResponseProxy
    {
        public UpdateCategoryResponseProxy()
        {
            status = 0;
            requestTime = DateTime.UtcNow;
        }
        public int status { get; set; }
        public string message { get; set; }
        public DateTime requestTime { get; set; }
        public DateTime responseTime { get; set; }
    }
    public class UpdateProductResponseProxy
    {
        public UpdateProductResponseProxy()
        {
            status = 0;
            requestTime = DateTime.UtcNow;
        }
        public int status { get; set; }
        public string message { get; set; }
        public DateTime requestTime { get; set; }
        public DateTime responseTime { get; set; }
    }
}
