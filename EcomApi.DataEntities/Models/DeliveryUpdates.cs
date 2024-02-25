using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcomApi.DataEntities.Models
{
    [Table("DeliveryUpdates")]
    public class DeliveryUpdates
    {
        [Key]
        public int UpdateID { get; set; }
        public int? DeliveryID { get; set; }
        public DateTime? UpdateDateTime { get; set; }
        public int? UpdateStatusID { get; set; }
        public string? Remarks { get; set; }
        public virtual Deliveries OrDeliveriesders { get; set; }
    }
}
