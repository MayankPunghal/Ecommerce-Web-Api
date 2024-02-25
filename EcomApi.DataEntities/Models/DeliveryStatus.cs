using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcomApi.DataEntities.Models
{
    [Table("DeliveryStatus")]
    public class DeliveryStatus
    {
        [Key]
        public int DeliveryStatusID { get; set; }
        public string StatusName { get; set; }

    }

}
