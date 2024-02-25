using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcomApi.DataEntities.Models
{
    [Table("Complaints")]
    public class Complaints
    {
        [Key]
        public int ComplaintID { get; set; }
        public int? UserID { get; set; }
        public int? OrderID { get; set; }
        public string Description { get; set; }
        public bool IsResolved { get; set; }
        public DateTime? ResolutionDate { get; set; }
        public int? ResolutionStatusID { get; set; }

        public virtual Users Users{ get; set; }
        public virtual Orders Orders { get; set; }
        public virtual ComplaintResolutionStatus ComplaintResolutionStatus { get; set; }

    }

}
