using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcomApi.DataEntities.ViewModels
{
    [Table("ComplaintResolutionDashboard")]
    public class ComplaintResolutionDashboardViewModel
    {
        [Key]
        public int ComplaintID { get; set; }

        public string Description { get; set; }
        public int ResolutionStatusID { get; set; }
        public string ResolutionStatusName { get; set; }
        public bool IsResolved { get; set; }
        public DateTime? ResolutionDate { get; set; }
    }
}
