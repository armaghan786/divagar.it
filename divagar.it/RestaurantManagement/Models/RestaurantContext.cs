using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace RestaurantManagement.Models
{
    public class RestaurantContext : IdentityDbContext<IdentityUser>
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options)
       : base(options)
        {
        }
        public DbSet<FoodCategory> FoodCategories { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<WineCategory> WineCategories { get; set; }
        public DbSet<WineSubcategory> WineSubcategories { get; set; }
        public DbSet<WineItem> WineItems { get; set; }
        public DbSet<FoodItemTranslation> FoodItemTranslations { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<BookingType> BookingTypes { get; set; }
        public virtual DbSet<AsportoCategory> AsportoCategories { get; set; }
        public virtual DbSet<AsportoItem> AsportoItems { get; set; }
        public virtual DbSet<BevandeCategory> BevandeCategories { get; set; }
        public virtual DbSet<BevandeItem> BevandeItems { get; set; }

    }
}
