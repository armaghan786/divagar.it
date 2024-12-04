using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagement.Models
{
    public class WineSubcategory
    {
        [Key]
        public int SubcategoryID { get; set; }
        public int CategoryID { get; set; }
        public string SubcategoryName { get; set; }
        public int? OrderBy { get; set; }
        [ForeignKey("CategoryID")]
        public WineCategory? WineCategory { get; set; }
        public ICollection<WineItem>? WineItems { get; set; }
    }
}
