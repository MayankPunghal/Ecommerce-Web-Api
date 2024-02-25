using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcomApi.DataEntities.Models
{
    [Table("Categories")]
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string? CategoryDescription { get; set; }

    }
}
