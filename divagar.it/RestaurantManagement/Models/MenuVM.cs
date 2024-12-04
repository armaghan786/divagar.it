namespace RestaurantManagement.Models
{
    public class MenuVM
    {
        public List<FoodCategory> FoodCategories { get; set; }
        public List<WineCategory> WineCategories { get; set; }
        public List<AsportoCategory> AsportoCategory { get; set; }
        public List<BevandeCategory> BevandeCategory { get; set; }
    }
}
