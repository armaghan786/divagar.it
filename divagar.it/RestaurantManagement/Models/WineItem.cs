using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagement.Models
{
    public class WineItem
    {
        [Key]
        public int ItemID { get; set; }
        public int SubcategoryID { get; set; }
        public string ItemName { get; set; }
        public string ItemPrice { get; set; }
        public bool IsAvailable { get; set; }
        public int? OrderBy { get; set; }
        [ForeignKey("SubcategoryID")]
        public WineSubcategory? WineSubcategory { get; set; }
    }
}
