using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Models
{
    public partial class AsportoItem
    {
        [Key]
        public int ItemID { get; set; }
        public int? CategoryID { get; set; }
        public string? ItemName { get; set; }
        public string? ItemPrice { get; set; }
        public bool IsAvailable { get; set; }
        public string? Allergens { get; set; }
        public string? Subtext { get; set; }
        public string? ItemNameEnglish { get; set; }
        public string? ItemPriceEnglish { get; set; }
        public string? SubtextEnglish { get; set; }
        public string? ItemNameSpanish { get; set; }
        public string? ItemPriceSpanish { get; set; }
        public string? SubtextSpanish { get; set; }
        public string? ItemNameFrance { get; set; }
        public string? ItemPriceFrance { get; set; }
        public string? SubtextFrance { get; set; }
        public string? ItemNameGermany { get; set; }
        public string? ItemPriceGermany { get; set; }
        public string? SubtextGermany { get; set; }
        public int? OrderId { get; set; }

        public virtual AsportoCategory? Category { get; set; }
    }
}
