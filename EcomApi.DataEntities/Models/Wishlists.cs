using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcomApi.DataEntities.Models
{
    [Table("Wishlists")]
    public class Wishlists
    {
        [Key]
        public int WishlistID { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public DateTime? AddedDate { get; set; }
        public virtual Products Products { get; set; }
        public virtual Users Users{ get; set; }

    }

}
