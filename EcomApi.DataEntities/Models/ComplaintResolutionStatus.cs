using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcomApi.DataEntities.Models
{
    [Table("ComplaintResolutionStatus")]
    public class ComplaintResolutionStatus
    {
        [Key]
        public int ResolutionStatusID { get; set; }
        public string ResolutionStatusName { get; set; }

    }
}
