using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Models
{
    public class FoodItemTranslation
    {
        [Key]
        public int ItemID { get; set; }
        public int CategoryID { get; set; }
        public string? ItemName { get; set; }
        public string? ItemPrice { get; set; }
        public string? Subtext { get; set; }
    }
}
