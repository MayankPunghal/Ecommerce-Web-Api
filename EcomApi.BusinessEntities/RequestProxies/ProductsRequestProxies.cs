using System.ComponentModel.DataAnnotations.Schema;

namespace EcomApi.BusinessEntities.RequestProxies
{
    public class UserData
    {
        public string? Token { get; set; }
        public int? UserId { get; set; }
    }
    public class GetProductRequestProxy
    {
        public UserData? UserData { get; set; }
    }
    public class GetCategoryRequestProxy
    {
        public UserData? UserData { get; set; }
    }
    public class GetProductByIdRequestProxy
    {
        public UserData? UserData { get; set; }
        public int ProductId { get; set; }
    }
    public class SetProductRequestProxy
    {
        public UserData? UserData { get; set; }
        public string ProductName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string? ImageName { get; set; }
        public int? CategoryId { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
    public class SetCategoryRequestProxy
    {
        public UserData? UserData { get; set; }
        public string CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
    }
    public class DeleteCategoryRequestProxy
    {
        public UserData? UserData { get; set; }
        public int CategoryId { get; set; }
    }
    public class DeletProductRequestProxy
    {
        public UserData? UserData { get; set; }
        public int ProductId { get; set; }
    }
    public class UpdateCategoryRequestProxy
    {
        public UserData? UserData { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
    }
    public class UpdateProductRequestProxy
    {
        public UserData? UserData { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string? ImageName { get; set; }
        public bool IsActive { get; set; }
        public int? CategoryId { get; set; }
    }
}
