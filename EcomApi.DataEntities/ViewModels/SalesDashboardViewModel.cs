using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcomApi.DataEntities.ViewModels
{
    [Table("SalesDashboard")]
    public class SalesDashboardViewModel
    {
        [Key]
        public int OrderID { get; set; }

        public int UserID { get; set; }
        public string UserName { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int NumberOfProducts { get; set; }
        public int TotalUnitsSold { get; set; }
    }
}
