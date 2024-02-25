using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcomApi.DataEntities.Models
{
    [Table("Coupons")]
    public class Coupons
    {
        [Key]
        public int CouponID { get; set; }
        public string CouponCode { get; set; }
        public int DiscountPercentage { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }

    }

}
