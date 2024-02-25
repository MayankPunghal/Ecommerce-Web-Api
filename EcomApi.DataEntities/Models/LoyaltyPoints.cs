using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcomApi.DataEntities.Models
{
    [Table("LoyaltyPoints")]
    public class LoyaltyPoints
    {
        [Key]
        public int LoyaltyPointsID { get; set; }
        public int? UserID { get; set; }
        public int PointsEarned { get; set; }
        public int PointsSpent { get; set; }
        public virtual Users Users { get; set; }
    }


}
