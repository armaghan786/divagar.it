using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagement.Models
{
    public class FoodItem
    {
        [Key]
        public int ItemID { get; set; }
        public int CategoryID { get; set; }
        public string ItemName { get; set; }
        public string ItemPrice { get; set; }
        public bool IsAvailable { get; set; }
        public string? Allergens { get; set; }
        public string? Subtext { get; set; }
        public int? OrderId { get; set; }

        [ForeignKey("CategoryID")]
        public FoodCategory? FoodCategory { get; set; }

        // English
        public string? ItemNameEnglish { get; set; }
        public string? ItemPriceEnglish { get; set; }
        public string? SubtextEnglish { get; set; }

        // Spanish
        public string? ItemNameSpanish { get; set; }
        public string? ItemPriceSpanish { get; set; }
        public string? SubtextSpanish { get; set; }

        // French
        public string? ItemNameFrance { get; set; }
        public string? ItemPriceFrance { get; set; }
        public string? SubtextFrance { get; set; }

        // German
        public string? ItemNameGermany { get; set; }
        public string? ItemPriceGermany { get; set; }
        public string? SubtextGermany { get; set; }
    }

}
