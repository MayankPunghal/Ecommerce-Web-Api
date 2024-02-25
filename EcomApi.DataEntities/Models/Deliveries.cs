using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcomApi.DataEntities.Models
{
    [Table("Deliveries")]
    public class Deliveries
    {
        [Key]
        public int DeliveryID { get; set; }
        public int? OrderID { get; set; }
        public int? DeliveryStatusID { get; set; }
        public DateTime? ScheduledDeliveryDate { get; set; }
        public DateTime? ActualDeliveryDate { get; set; }
        public string? DriverName { get; set; }
        public virtual DeliveryStatus DeliveryStatus { get; set; }
        public virtual Orders Orders { get; set; }


    }
}
