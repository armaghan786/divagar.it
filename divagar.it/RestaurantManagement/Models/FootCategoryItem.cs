namespace RestaurantManagement.Models
{
    public class FootCategoryItem
    {
        public List<FoodCategory> Category { get; set; }
        public List<FoodItem> FoodItems { get; set; }
    }

    public class AsportoCategoryItem
    {
        public List<AsportoCategory> Category { get; set; }
        public List<AsportoItem> FoodItems { get; set; }
    }
    public class BevandeCategoryItem
    {
        public List<BevandeCategory> Category { get; set; }
        public List<BevandeItem> FoodItems { get; set; }
    }
}
