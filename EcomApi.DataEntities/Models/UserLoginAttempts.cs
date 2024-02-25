using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcomApi.DataEntities.Models
{
    [Table("UserLoginAttempts")]
    public class UserLoginAttempts
    {
        [Key]
        public int AttemptID { get; set; }
        public int UserID { get; set; }
        public DateTime AttemptDateTime { get; set; }
        public bool IsSuccessful { get; set; }
        public int AttemptCount { get; set; }

    }
}
