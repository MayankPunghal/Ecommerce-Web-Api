using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcomApi.DataEntities.ViewModels
{
    [Table("DeliveryUpdatesDashboard")]
    public class DeliveryUpdatesDashboardViewModel
    {
        [Key]
        public int DeliveryID { get; set; }

        public int OrderID { get; set; }
        public string DeliveryStatus { get; set; }
        public DateTime ScheduledDeliveryDate { get; set; }
        public string ActualDeliveryDate { get; set; }
        public string DriverName { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public string UpdateStatus { get; set; }
        public string Remarks { get; set; }
    }
}
