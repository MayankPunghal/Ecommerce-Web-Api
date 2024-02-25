using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using EcomApi.DataEntities.Models;

namespace EcomApi.DataEntities.Models
{
    [Table("OrderDetails")]
    public class OrderDetails
    {
        [Key, Column(Order = 0)]
        public int OrderID { get; set; }
        public virtual Orders Orders { get; set; }
        [Key, Column(Order = 1)]
        public int ProductID { get; set; }
        public virtual Products Products { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

    }
}
