using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Models
{
    public class WineCategory
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int? OrderBy { get; set; }
        public ICollection<WineSubcategory>? WineSubcategories { get; set; }
    }
}
