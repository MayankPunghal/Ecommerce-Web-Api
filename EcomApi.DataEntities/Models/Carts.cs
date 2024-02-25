using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcomApi.DataEntities.Models
{
    [Table("Carts")]
    public class Carts
    {
        [Key]
        public int CartID { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public virtual Users Users { get; set; }
        public virtual Products Products { get; set; }
    }
}
