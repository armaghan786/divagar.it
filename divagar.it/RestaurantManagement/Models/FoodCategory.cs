using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Models
{
    public class FoodCategory
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string? CategoryNameEnglish { get; set; }
        public string? CategoryNameSpanish { get; set; }
        public string? CategoryNameFrance { get; set; }
        public string? CategoryNameGermany { get; set; }
        public int OrderId { get; set; }
        public ICollection<FoodItem>? FoodItems { get; set; }
    }
}
