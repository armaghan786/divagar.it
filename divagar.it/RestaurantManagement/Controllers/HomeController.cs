using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Models;
using System;
using System.Diagnostics;

namespace RestaurantManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RestaurantContext _context;
        private readonly string _correctPin;

        public HomeController(ILogger<HomeController> logger, RestaurantContext context, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _correctPin = configuration["Security:Pin"]; // Retrieve the PIN from configuration

        }

        public IActionResult Index21()
        {
            return View();
        }
        public async Task<IActionResult> AsportoMenu() => View();

        [HttpGet]
        public IActionResult GetAsportoMenu(string lang)
        {
            // Retrieve the food menu ordered by the OrderId of the category and by ItemName within each category
            var foodMenu = _context.AsportoCategories
                .Include(fc => fc.AsportoItems.Where(x => x.IsAvailable == true).OrderBy(x => x.OrderId))
                .OrderBy(x => x.OrderId) // Order the categories
                .ToList();

            var FootCategoryItem = new AsportoCategoryItem();
            if (lang == "IT")
            {
                FootCategoryItem.Category = foodMenu.Select(x => new AsportoCategory()
                {
                    CategoryID = x.CategoryID,
                    CategoryName = x.CategoryName,
                }).ToList();

                FootCategoryItem.FoodItems = foodMenu.SelectMany(x => x.AsportoItems)
                    .OrderBy(p => p.OrderId) // Order the food items by ItemName
                    .Select(p => new AsportoItem
                    {
                        CategoryID = p.CategoryID,
                        ItemID = p.ItemID,
                        ItemName = p.ItemName,
                        ItemPrice = p.ItemPrice,
                        Subtext = p.Subtext,
                        Allergens = p.Allergens,
                        IsAvailable = p.IsAvailable,
                        OrderId = p.OrderId

                    }).OrderBy(x => x.OrderId).ToList();
            }

            // Repeat similar changes for other languages (EN, ES, FR, DE)
            else if (lang == "EN")
            {
                FootCategoryItem.Category = foodMenu.Select(x => new AsportoCategory()
                {
                    CategoryID = x.CategoryID,
                    CategoryNameEnglish = x.CategoryNameEnglish,
                }).ToList();

                FootCategoryItem.FoodItems = foodMenu.SelectMany(x => x.AsportoItems)
                    .OrderBy(p => p.OrderId) // Order the food items by ItemNameEnglish
                    .Select(p => new AsportoItem
                    {
                        CategoryID = p.CategoryID,
                        ItemID = p.ItemID,
                        Allergens = p.Allergens,

                        // English
                        ItemNameEnglish = p.ItemNameEnglish,
                        ItemPriceEnglish = p.ItemPriceEnglish,
                        SubtextEnglish = p.SubtextEnglish,
                        IsAvailable = p.IsAvailable
                    }).ToList();
            }
            // Repeat similar changes for other languages (EN, ES, FR, DE)
            else if (lang == "ES")
            {
                FootCategoryItem.Category = foodMenu.Select(x => new AsportoCategory()
                {
                    CategoryID = x.CategoryID,
                    CategoryNameSpanish = x.CategoryNameSpanish,
                }).ToList();

                FootCategoryItem.FoodItems = foodMenu.SelectMany(x => x.AsportoItems)
                    .OrderBy(p => p.OrderId) // Order the food items by ItemNameEnglish
                    .Select(p => new AsportoItem
                    {
                        CategoryID = p.CategoryID,
                        ItemID = p.ItemID,
                        Allergens = p.Allergens,

                        // Spanish
                        ItemNameSpanish = p.ItemNameSpanish,
                        ItemPriceSpanish = p.ItemPriceSpanish,
                        SubtextSpanish = p.SubtextSpanish,
                        IsAvailable = p.IsAvailable
                    }).ToList();
            }
            else if (lang == "FR")
            {
                FootCategoryItem.Category = foodMenu.Select(x => new AsportoCategory()
                {
                    CategoryID = x.CategoryID,
                    CategoryNameFrance = x.CategoryNameFrance,
                }).ToList();

                FootCategoryItem.FoodItems = foodMenu.SelectMany(x => x.AsportoItems)
                    .OrderBy(p => p.OrderId) // Order the food items by ItemNameEnglish
                    .Select(p => new AsportoItem
                    {
                        CategoryID = p.CategoryID,
                        ItemID = p.ItemID,
                        Allergens = p.Allergens,

                        // France
                        ItemNameFrance = p.ItemNameFrance,
                        ItemPriceFrance = p.ItemPriceFrance,
                        SubtextFrance = p.SubtextFrance,
                        IsAvailable = p.IsAvailable
                    }).ToList();
            }
            else
            {
                FootCategoryItem.Category = foodMenu.Select(x => new AsportoCategory()
                {
                    CategoryID = x.CategoryID,
                    CategoryNameGermany = x.CategoryNameGermany,
                }).ToList();

                FootCategoryItem.FoodItems = foodMenu.SelectMany(x => x.AsportoItems)
                    .OrderBy(p => p.OrderId) // Order the food items by ItemNameEnglish
                    .Select(p => new AsportoItem
                    {
                        CategoryID = p.CategoryID,
                        ItemID = p.ItemID,
                        Allergens = p.Allergens,

                        // English
                        ItemNameGermany = p.ItemNameGermany,
                        ItemPriceGermany = p.ItemPriceGermany,
                        SubtextGermany = p.SubtextGermany,
                        IsAvailable = p.IsAvailable
                    }).ToList();
            }
            // Similar for ES, FR, DE
            // ...

            return Json(FootCategoryItem);
        }

        public async Task<IActionResult> BevandeMenu() => View();

        [HttpGet]
        public IActionResult GetBevandeMenu(string lang)
        {
            // Retrieve the food menu ordered by the OrderId of the category and by ItemName within each category
            var foodMenu = _context.BevandeCategories
                .Include(fc => fc.BevandeItems.Where(x => x.IsAvailable == true).OrderBy(x => x.OrderId))
                .OrderBy(x => x.OrderId) // Order the categories
                .ToList();

            var FootCategoryItem = new BevandeCategoryItem();
            if (lang == "IT")
            {
                FootCategoryItem.Category = foodMenu.Select(x => new BevandeCategory()
                {
                    CategoryID = x.CategoryID,
                    CategoryName = x.CategoryName,
                }).ToList();

                FootCategoryItem.FoodItems = foodMenu.SelectMany(x => x.BevandeItems)
                    .OrderBy(p => p.OrderId) // Order the food items by ItemName
                    .Select(p => new BevandeItem
                    {
                        CategoryID = p.CategoryID,
                        ItemID = p.ItemID,
                        ItemName = p.ItemName,
                        ItemPrice = p.ItemPrice,
                        Subtext = p.Subtext,
                        Allergens = p.Allergens,
                        IsAvailable = p.IsAvailable,
                        OrderId = p.OrderId

                    }).OrderBy(x => x.OrderId).ToList();
            }

            // Repeat similar changes for other languages (EN, ES, FR, DE)
            else if (lang == "EN")
            {
                FootCategoryItem.Category = foodMenu.Select(x => new BevandeCategory()
                {
                    CategoryID = x.CategoryID,
                    CategoryNameEnglish = x.CategoryNameEnglish,
                }).ToList();

                FootCategoryItem.FoodItems = foodMenu.SelectMany(x => x.BevandeItems)
                    .OrderBy(p => p.OrderId) // Order the food items by ItemNameEnglish
                    .Select(p => new BevandeItem
                    {
                        CategoryID = p.CategoryID,
                        ItemID = p.ItemID,
                        Allergens = p.Allergens,

                        // English
                        ItemNameEnglish = p.ItemNameEnglish,
                        ItemPriceEnglish = p.ItemPriceEnglish,
                        SubtextEnglish = p.SubtextEnglish,
                        IsAvailable = p.IsAvailable
                    }).ToList();
            }
            // Repeat similar changes for other languages (EN, ES, FR, DE)
            else if (lang == "ES")
            {
                FootCategoryItem.Category = foodMenu.Select(x => new BevandeCategory()
                {
                    CategoryID = x.CategoryID,
                    CategoryNameSpanish = x.CategoryNameSpanish,
                }).ToList();

                FootCategoryItem.FoodItems = foodMenu.SelectMany(x => x.BevandeItems)
                    .OrderBy(p => p.OrderId) // Order the food items by ItemNameEnglish
                    .Select(p => new BevandeItem
                    {
                        CategoryID = p.CategoryID,
                        ItemID = p.ItemID,
                        Allergens = p.Allergens,

                        // Spanish
                        ItemNameSpanish = p.ItemNameSpanish,
                        ItemPriceSpanish = p.ItemPriceSpanish,
                        SubtextSpanish = p.SubtextSpanish,
                        IsAvailable = p.IsAvailable
                    }).ToList();
            }
            else if (lang == "FR")
            {
                FootCategoryItem.Category = foodMenu.Select(x => new BevandeCategory()
                {
                    CategoryID = x.CategoryID,
                    CategoryNameFrance = x.CategoryNameFrance,
                }).ToList();

                FootCategoryItem.FoodItems = foodMenu.SelectMany(x => x.BevandeItems)
                    .OrderBy(p => p.OrderId) // Order the food items by ItemNameEnglish
                    .Select(p => new BevandeItem
                    {
                        CategoryID = p.CategoryID,
                        ItemID = p.ItemID,
                        Allergens = p.Allergens,

                        // France
                        ItemNameFrance = p.ItemNameFrance,
                        ItemPriceFrance = p.ItemPriceFrance,
                        SubtextFrance = p.SubtextFrance,
                        IsAvailable = p.IsAvailable
                    }).ToList();
            }
            else
            {
                FootCategoryItem.Category = foodMenu.Select(x => new BevandeCategory()
                {
                    CategoryID = x.CategoryID,
                    CategoryNameGermany = x.CategoryNameGermany,
                }).ToList();

                FootCategoryItem.FoodItems = foodMenu.SelectMany(x => x.BevandeItems)
                    .OrderBy(p => p.OrderId) // Order the food items by ItemNameEnglish
                    .Select(p => new BevandeItem
                    {
                        CategoryID = p.CategoryID,
                        ItemID = p.ItemID,
                        Allergens = p.Allergens,

                        // English
                        ItemNameGermany = p.ItemNameGermany,
                        ItemPriceGermany = p.ItemPriceGermany,
                        SubtextGermany = p.SubtextGermany,
                        IsAvailable = p.IsAvailable
                    }).ToList();
            }
            // Similar for ES, FR, DE
            // ...

            return Json(FootCategoryItem);
        }

        public async Task<IActionResult> FoodMenu()
        {
            // var foodMenu = await _context.FoodCategories
            //.Include(fc => fc.FoodItems)
            //.ToListAsync();

            return View();
        }
        [HttpGet]
        public IActionResult GetFoodMenu(string lang)
        {
            // Retrieve the food menu ordered by the OrderId of the category and by ItemName within each category
            var foodMenu = _context.FoodCategories
                .Include(fc => fc.FoodItems.Where(x => x.IsAvailable == true).OrderBy(x => x.OrderId))
                .OrderBy(x => x.OrderId) // Order the categories
                .ToList();

            var FootCategoryItem = new FootCategoryItem();
            if (lang == "IT")
            {
                FootCategoryItem.Category = foodMenu.Select(x => new FoodCategory()
                {
                    CategoryID = x.CategoryID,
                    CategoryName = x.CategoryName,
                }).ToList();

                FootCategoryItem.FoodItems = foodMenu.SelectMany(x => x.FoodItems)
                    .OrderBy(p => p.OrderId) // Order the food items by ItemName
                    .Select(p => new FoodItem
                    {
                        CategoryID = p.CategoryID,
                        ItemID = p.ItemID,
                        ItemName = p.ItemName,
                        ItemPrice = p.ItemPrice,
                        Subtext = p.Subtext,
                        Allergens = p.Allergens,
                        IsAvailable = p.IsAvailable,
                        OrderId = p.OrderId

                    }).OrderBy(x => x.OrderId).ToList();
            }

            // Repeat similar changes for other languages (EN, ES, FR, DE)
            else if (lang == "EN")
            {
                FootCategoryItem.Category = foodMenu.Select(x => new FoodCategory()
                {
                    CategoryID = x.CategoryID,
                    CategoryNameEnglish = x.CategoryNameEnglish,
                }).ToList();

                FootCategoryItem.FoodItems = foodMenu.SelectMany(x => x.FoodItems)
                    .OrderBy(p => p.OrderId) // Order the food items by ItemNameEnglish
                    .Select(p => new FoodItem
                    {
                        CategoryID = p.CategoryID,
                        ItemID = p.ItemID,
                        Allergens = p.Allergens,

                        // English
                        ItemNameEnglish = p.ItemNameEnglish,
                        ItemPriceEnglish = p.ItemPriceEnglish,
                        SubtextEnglish = p.SubtextEnglish,
                        IsAvailable = p.IsAvailable
                    }).ToList();
            }
            // Repeat similar changes for other languages (EN, ES, FR, DE)
            else if (lang == "ES")
            {
                FootCategoryItem.Category = foodMenu.Select(x => new FoodCategory()
                {
                    CategoryID = x.CategoryID,
                    CategoryNameSpanish = x.CategoryNameSpanish,
                }).ToList();

                FootCategoryItem.FoodItems = foodMenu.SelectMany(x => x.FoodItems)
                    .OrderBy(p => p.OrderId) // Order the food items by ItemNameEnglish
                    .Select(p => new FoodItem
                    {
                        CategoryID = p.CategoryID,
                        ItemID = p.ItemID,
                        Allergens = p.Allergens,

                        // Spanish
                        ItemNameSpanish = p.ItemNameSpanish,
                        ItemPriceSpanish = p.ItemPriceSpanish,
                        SubtextSpanish = p.SubtextSpanish,
                        IsAvailable = p.IsAvailable
                    }).ToList();
            }
            else if (lang == "FR")
            {
                FootCategoryItem.Category = foodMenu.Select(x => new FoodCategory()
                {
                    CategoryID = x.CategoryID,
                    CategoryNameFrance = x.CategoryNameFrance,
                }).ToList();

                FootCategoryItem.FoodItems = foodMenu.SelectMany(x => x.FoodItems)
                    .OrderBy(p => p.OrderId) // Order the food items by ItemNameEnglish
                    .Select(p => new FoodItem
                    {
                        CategoryID = p.CategoryID,
                        ItemID = p.ItemID,
                        Allergens = p.Allergens,

                        // France
                        ItemNameFrance = p.ItemNameFrance,
                        ItemPriceFrance = p.ItemPriceFrance,
                        SubtextFrance = p.SubtextFrance,
                        IsAvailable = p.IsAvailable
                    }).ToList();
            }
            else
            {
                FootCategoryItem.Category = foodMenu.Select(x => new FoodCategory()
                {
                    CategoryID = x.CategoryID,
                    CategoryNameGermany = x.CategoryNameGermany,
                }).ToList();

                FootCategoryItem.FoodItems = foodMenu.SelectMany(x => x.FoodItems)
                    .OrderBy(p => p.OrderId) // Order the food items by ItemNameEnglish
                    .Select(p => new FoodItem
                    {
                        CategoryID = p.CategoryID,
                        ItemID = p.ItemID,
                        Allergens = p.Allergens,

                        // English
                        ItemNameGermany = p.ItemNameGermany,
                        ItemPriceGermany = p.ItemPriceGermany,
                        SubtextGermany = p.SubtextGermany,
                        IsAvailable = p.IsAvailable
                    }).ToList();
            }
            // Similar for ES, FR, DE
            // ...

            return Json(FootCategoryItem);
        }


        public async Task<IActionResult> WineMenu()
        {
            var wineMenu = await _context.WineCategories.OrderBy(x => x.OrderBy)
           .Include(fc => fc.WineSubcategories)
           .ThenInclude(fc => fc.WineItems.Where(x => x.IsAvailable == true))
           .ToListAsync();

            return View(wineMenu);
        }
        [HttpGet]
        [Route("enterpin")] // Custom route for accessing the PIN entry page

        public IActionResult EnterPin()
        {
            return View(new EnterPinViewModel());
        }

        // Handle the PIN verification
        [HttpPost]
        [Route("Verifypin")] // Custom route for verifying the entered PIN

        public IActionResult VerifyPin(EnterPinViewModel model)
        {
            if (model.Pin == _correctPin)
            {
                HttpContext.Session.SetString("PinVerified", "true");
                return RedirectToAction("Menu");
            }
            model.ErrorMessage = "PIN errato, riprova.";
            return View("EnterPin", model);
        }
        [Route("webappmenu")]

        public async Task<IActionResult> Menu()
        { // Check if the user has entered the correct PIN
            var isPinVerified = HttpContext.Session.GetString("PinVerified");

            if (isPinVerified != "true")
            {
                // Redirect to the PIN input page if not verified
                return RedirectToAction("EnterPin");
            }
            var asportoMenu = await _context.AsportoCategories.OrderBy(x => x.OrderId)
           .Include(fc => fc.AsportoItems.OrderBy(x => x.OrderId))
           .ToListAsync();

            var bevandeMenu = await _context.BevandeCategories.OrderBy(x => x.OrderId)
.Include(fc => fc.BevandeItems.OrderBy(x => x.OrderId))
.ToListAsync();
            var foodMenu = await _context.FoodCategories.OrderBy(x => x.OrderId)
.Include(fc => fc.FoodItems.OrderBy(x => x.OrderId))
.ToListAsync();
            var wineMenu = await _context.WineCategories.OrderBy(x => x.OrderBy)
           .Include(fc => fc.WineSubcategories.OrderBy(x => x.OrderBy))
           .ThenInclude(fc => fc.WineItems.OrderBy(x => x.OrderBy))
           .ToListAsync();

            var menu = new MenuVM();
            menu.FoodCategories = foodMenu;
            menu.WineCategories = wineMenu;
            menu.AsportoCategory = asportoMenu;
            menu.BevandeCategory = bevandeMenu;
            return View(menu);
        }
        [HttpPost]
        public async Task<IActionResult> MoveWiseCategory([FromBody] MoveRequest request)
        {
            var category = await _context.WineCategories.FindAsync(request.CategoryId);
            var categories = _context.WineCategories.OrderBy(x => x.OrderBy).ToList();

            if (category == null || categories.Count == 0) return NotFound();

            var index = categories.IndexOf(category);
            if (index < 0) return BadRequest("Category not found in the list.");

            // Handle moving up/down
            if (request.Direction == "up" && index > 0)
            {
                var aboveCategory = categories[index - 1];
                SwapOrder(category, aboveCategory);
            }
            else if (request.Direction == "down" && index < categories.Count - 1)
            {
                var belowCategory = categories[index + 1];
                SwapOrder(category, belowCategory);
            }

            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> MoveSubcategory([FromBody] MoveRequest request)
        {
            var subcategory = await _context.WineSubcategories.FindAsync(request.SubcategoryId);
            var subcategories = _context.WineSubcategories.Where(x => x.CategoryID == subcategory.CategoryID).OrderBy(x => x.OrderBy).ToList();

            if (subcategory == null || subcategories.Count == 0) return NotFound();

            var index = subcategories.IndexOf(subcategory);
            if (index < 0) return BadRequest("Subcategory not found in the list.");

            if (request.Direction == "up" && index > 0)
            {
                var aboveSubcategory = subcategories[index - 1];
                SwapOrder(subcategory, aboveSubcategory);
            }
            else if (request.Direction == "down" && index < subcategories.Count - 1)
            {
                var belowSubcategory = subcategories[index + 1];
                SwapOrder(subcategory, belowSubcategory);
            }

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> MoveWineItem([FromBody] MoveRequest request)
        {
            var item = await _context.WineItems.FindAsync(request.ItemId);
            var items = _context.WineItems.Where(x => x.SubcategoryID == item.SubcategoryID).OrderBy(x => x.OrderBy).ToList();

            if (item == null || items.Count == 0) return NotFound();

            var index = items.IndexOf(item);
            if (index < 0) return BadRequest("Item not found in the list.");

            if (request.Direction == "up" && index > 0)
            {
                var aboveItem = items[index - 1];
                SwapOrder(item, aboveItem);
            }
            else if (request.Direction == "down" && index < items.Count - 1)
            {
                var belowItem = items[index + 1];
                SwapOrder(item, belowItem);
            }

            await _context.SaveChangesAsync();
            return Ok();
        }
        private void SwapOrder(WineCategory category1, WineCategory category2)
        {
            int? tempOrder = category1.OrderBy;
            category1.OrderBy = category2.OrderBy;
            category2.OrderBy = tempOrder;
        }
        private void SwapOrder(WineSubcategory category1, WineSubcategory category2)
        {
            int? tempOrder = category1.OrderBy;
            category1.OrderBy = category2.OrderBy;
            category2.OrderBy = tempOrder;
        }
        private void SwapOrder(WineItem category1, WineItem category2)
        {
            int? tempOrder = category1.OrderBy;
            category1.OrderBy = category2.OrderBy;
            category2.OrderBy = tempOrder;
        }
        public class MoveRequest
        {
            public int CategoryId { get; set; }
            public int SubcategoryId { get; set; }
            public int ItemId { get; set; }
            public string Direction { get; set; }
        }
        [HttpPost]
        [HttpPost]
        public IActionResult MoveCategory(int categoryId, string direction)
        {
            var category = _context.FoodCategories.Find(categoryId);
            if (category == null) return Json(new { success = false });

            // Get all categories ordered by OrderId
            var categories = _context.FoodCategories.OrderBy(c => c.OrderId).ToList();

            // Find the index of the current category
            var currentIndex = categories.FindIndex(c => c.CategoryID == categoryId);

            if (direction == "up" && currentIndex > 0)
            {
                // Swap with the previous category
                var previousCategory = categories[currentIndex - 1];
                int tempOrderId = category.OrderId;
                category.OrderId = previousCategory.OrderId;
                previousCategory.OrderId = tempOrderId;
            }
            else if (direction == "down" && currentIndex < categories.Count - 1)
            {
                // Swap with the next category
                var nextCategory = categories[currentIndex + 1];
                int tempOrderId = category.OrderId;
                category.OrderId = nextCategory.OrderId;
                nextCategory.OrderId = tempOrderId;
            }

            _context.SaveChanges();
            return Json(new { success = true });
        }
        [HttpPost]
        public IActionResult MoveFoodItem(int itemId, string direction)
        {
            var foodItem = _context.FoodItems.Find(itemId);
            if (foodItem == null) return Json(new { success = false });

            // Get all food items in the current category ordered by OrderId
            var foodItems = _context.FoodItems
                .Where(f => f.CategoryID == foodItem.CategoryID)
                .OrderBy(f => f.OrderId)
                .ToList();

            // Find the index of the current food item
            var currentIndex = foodItems.FindIndex(f => f.ItemID == itemId);

            if (direction == "up" && currentIndex > 0)
            {
                // Swap with the previous food item
                var previousFoodItem = foodItems[currentIndex - 1];
                int? tempOrderId = foodItem.OrderId;
                foodItem.OrderId = previousFoodItem.OrderId;
                previousFoodItem.OrderId = tempOrderId;
            }
            else if (direction == "down" && currentIndex < foodItems.Count - 1)
            {
                // Swap with the next food item
                var nextFoodItem = foodItems[currentIndex + 1];
                int? tempOrderId = foodItem.OrderId;
                foodItem.OrderId = nextFoodItem.OrderId;
                nextFoodItem.OrderId = tempOrderId;
            }

            _context.SaveChanges();
            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult MoveAsporto(int categoryId, string direction)
        {
            var category = _context.AsportoCategories.Find(categoryId);
            if (category == null) return Json(new { success = false });

            // Get all categories ordered by OrderId
            var categories = _context.AsportoCategories.OrderBy(c => c.OrderId).ToList();

            // Find the index of the current category
            var currentIndex = categories.FindIndex(c => c.CategoryID == categoryId);

            if (direction == "up" && currentIndex > 0)
            {
                // Swap with the previous category
                var previousCategory = categories[currentIndex - 1];
                int tempOrderId = category.OrderId;
                category.OrderId = previousCategory.OrderId;
                previousCategory.OrderId = tempOrderId;
            }
            else if (direction == "down" && currentIndex < categories.Count - 1)
            {
                // Swap with the next category
                var nextCategory = categories[currentIndex + 1];
                int tempOrderId = category.OrderId;
                category.OrderId = nextCategory.OrderId;
                nextCategory.OrderId = tempOrderId;
            }

            _context.SaveChanges();
            return Json(new { success = true });
        }
        [HttpPost]
        public IActionResult MoveAsportoItem(int itemId, string direction)
        {
            var foodItem = _context.AsportoItems.Find(itemId);
            if (foodItem == null) return Json(new { success = false });

            // Get all food items in the current category ordered by OrderId
            var foodItems = _context.AsportoItems
                .Where(f => f.CategoryID == foodItem.CategoryID)
                .OrderBy(f => f.OrderId)
                .ToList();

            // Find the index of the current food item
            var currentIndex = foodItems.FindIndex(f => f.ItemID == itemId);

            if (direction == "up" && currentIndex > 0)
            {
                // Swap with the previous food item
                var previousFoodItem = foodItems[currentIndex - 1];
                int? tempOrderId = foodItem.OrderId;
                foodItem.OrderId = previousFoodItem.OrderId;
                previousFoodItem.OrderId = tempOrderId;
            }
            else if (direction == "down" && currentIndex < foodItems.Count - 1)
            {
                // Swap with the next food item
                var nextFoodItem = foodItems[currentIndex + 1];
                int? tempOrderId = foodItem.OrderId;
                foodItem.OrderId = nextFoodItem.OrderId;
                nextFoodItem.OrderId = tempOrderId;
            }

            _context.SaveChanges();
            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult MoveBevande(int categoryId, string direction)
        {
            var category = _context.BevandeCategories.Find(categoryId);
            if (category == null) return Json(new { success = false });

            // Get all categories ordered by OrderId
            var categories = _context.BevandeCategories.OrderBy(c => c.OrderId).ToList();

            // Find the index of the current category
            var currentIndex = categories.FindIndex(c => c.CategoryID == categoryId);

            if (direction == "up" && currentIndex > 0)
            {
                // Swap with the previous category
                var previousCategory = categories[currentIndex - 1];
                int tempOrderId = category.OrderId;
                category.OrderId = previousCategory.OrderId;
                previousCategory.OrderId = tempOrderId;
            }
            else if (direction == "down" && currentIndex < categories.Count - 1)
            {
                // Swap with the next category
                var nextCategory = categories[currentIndex + 1];
                int tempOrderId = category.OrderId;
                category.OrderId = nextCategory.OrderId;
                nextCategory.OrderId = tempOrderId;
            }

            _context.SaveChanges();
            return Json(new { success = true });
        }
        [HttpPost]
        public IActionResult MoveBevandeItem(int itemId, string direction)
        {
            var foodItem = _context.BevandeItems.Find(itemId);
            if (foodItem == null) return Json(new { success = false });

            // Get all food items in the current category ordered by OrderId
            var foodItems = _context.BevandeItems
                .Where(f => f.CategoryID == foodItem.CategoryID)
                .OrderBy(f => f.OrderId)
                .ToList();

            // Find the index of the current food item
            var currentIndex = foodItems.FindIndex(f => f.ItemID == itemId);

            if (direction == "up" && currentIndex > 0)
            {
                // Swap with the previous food item
                var previousFoodItem = foodItems[currentIndex - 1];
                int? tempOrderId = foodItem.OrderId;
                foodItem.OrderId = previousFoodItem.OrderId;
                previousFoodItem.OrderId = tempOrderId;
            }
            else if (direction == "down" && currentIndex < foodItems.Count - 1)
            {
                // Swap with the next food item
                var nextFoodItem = foodItems[currentIndex + 1];
                int? tempOrderId = foodItem.OrderId;
                foodItem.OrderId = nextFoodItem.OrderId;
                nextFoodItem.OrderId = tempOrderId;
            }

            _context.SaveChanges();
            return Json(new { success = true });
        }
        public async Task<IActionResult> MenuNavigator()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddFoodCategory(FoodCategory model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existingCategory = _context.FoodCategories
                        .Where(c => c.CategoryName.ToLower() == model.CategoryName).FirstOrDefault();

                    if (existingCategory != null)
                    {
                        return Json(new { success = false, message = "La categoria esiste già." });
                    }  // Determine the next OrderId
                    int nextOrderId = 1; // Default to 1 if this is the first entry
                    var highestOrderId = _context.FoodCategories.Max(c => (int?)c.OrderId);
                    if (highestOrderId.HasValue)
                    {
                        nextOrderId = highestOrderId.Value + 1;
                    }

                    // Set the OrderId for the new category
                    model.OrderId = nextOrderId;
                    _context.FoodCategories.Add(model);
                    _context.SaveChanges();

                    return Json(new { success = true, message = "Categoria aggiunta correttamente." });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
                }
            }
            return Json(new { success = false, message = "Invalid data received." });
        }

        [HttpPost]
        public IActionResult EditFoodCategory(FoodCategory model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existingCategory = _context.FoodCategories.Find(model.CategoryID);

                    if (existingCategory == null)
                    {
                        return Json(new { success = false, message ="Categoria non trovata." });
                    }

                    existingCategory.CategoryName = model.CategoryName;
                    existingCategory.CategoryNameEnglish = model.CategoryNameEnglish;
                    existingCategory.CategoryNameSpanish = model.CategoryNameSpanish;
                    existingCategory.CategoryNameFrance = model.CategoryNameFrance;
                    existingCategory.CategoryNameGermany = model.CategoryNameGermany;
                    _context.FoodCategories.Update(existingCategory);
                    _context.SaveChanges();

                    return Json(new { success = true, message = "Categoria aggiornata correttamente." });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
                }
            }
            return Json(new { success = false, message = "Invalid data received." });
        }

        [HttpDelete]
        public IActionResult DeleteFoodCategory(int id)
        {
            try
            {
                var category = _context.FoodCategories.Find(id);
                if (category == null)
                {
                    return Json(new { success = false, message ="Categoria non trovata." });
                }

                _context.FoodCategories.Remove(category);
                _context.SaveChanges();

                return Json(new { success = true, message = "Categoria eliminata correttamente." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
            }
        }

        [HttpPost]
        public IActionResult AddFoodItem(FoodItem model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existingItem = _context.FoodItems
                        .FirstOrDefault(i => i.ItemName == model.ItemName);
                    if (existingItem != null)
                    {
                        return Json(new { success = false, message ="L'articolo esiste già." });
                    }
                    // Determine the next OrderId for the new item in the given category
                    int nextOrderId = 1; // Default to 1 if no items exist in the category
                    var highestOrderId = _context.FoodItems
                        .Where(i => i.CategoryID == model.CategoryID)
                        .Max(i => (int?)i.OrderId); // Get the highest OrderId in this category

                    if (highestOrderId.HasValue)
                    {
                        nextOrderId = highestOrderId.Value + 1;
                    }

                    // Set the OrderId for the new item
                    model.OrderId = nextOrderId;
                    _context.FoodItems.Add(model);
                    _context.SaveChanges();

                    return Json(new { success = true, message = "Articolo aggiunto correttamente." });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
                }
            }
            return Json(new { success = false, message = "Invalid data received." });
        }

        [HttpPost]
        public IActionResult EditFoodItem(FoodItem model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var item = _context.FoodItems
                        .FirstOrDefault(i => i.ItemID == model.ItemID);

                    if (item == null)
                    {
                        return Json(new { success = false, message = "Articolo non trovato." });
                    }

                    item.ItemName = model.ItemName;
                    item.Subtext = model.Subtext;
                    item.ItemPrice = model.ItemPrice;
                    item.Allergens = model.Allergens;

                    item.ItemNameEnglish = model.ItemNameEnglish;
                    item.SubtextEnglish = model.SubtextEnglish;
                    item.ItemPriceEnglish = model.ItemPriceEnglish;

                    item.ItemNameSpanish = model.ItemNameSpanish;
                    item.SubtextSpanish = model.SubtextSpanish;
                    item.ItemPriceSpanish = model.ItemPriceSpanish;

                    item.ItemNameFrance = model.ItemNameFrance;
                    item.SubtextFrance = model.SubtextFrance;
                    item.ItemPriceFrance = model.ItemPriceFrance;

                    item.ItemNameGermany = model.ItemNameGermany;
                    item.SubtextGermany = model.SubtextGermany;
                    item.ItemPriceGermany = model.ItemPriceGermany;



                    _context.FoodItems.Update(item);
                    _context.SaveChanges();

                    return Json(new { success = true, message = "Articolo aggiornato correttamente." });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
                }
            }
            return Json(new { success = false, message = "Invalid data received." });
        }

        [HttpDelete]
        public IActionResult RemoveFoodItem(int ItemID)
        {
            try
            {
                var item = _context.FoodItems
                    .FirstOrDefault(i => i.ItemID == ItemID);

                if (item == null)
                {
                    return Json(new { success = false, message = "Articolo non trovato." });
                }

                _context.FoodItems.Remove(item);
                _context.SaveChanges();

                return Json(new { success = true, message = "Articolo rimosso con successo." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
            }
        }
        [HttpPost]
        public IActionResult toggleAvailability(int ItemID, bool IsAvailable)
        {
            try
            {
                var item = _context.FoodItems
                    .FirstOrDefault(i => i.ItemID == ItemID);

                if (item == null)
                {
                    return Json(new { success = false, message = "Articolo non trovato." });
                }
                item.IsAvailable = IsAvailable;
                _context.FoodItems.Update(item);
                _context.SaveChanges();

                return Json(new { success = true, message = "Operazione riuscita." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
            }
        }

        #region Asporto
        [HttpPost]
        public IActionResult AddAsportoCategory(AsportoCategory model)
        {
           
                try
                {
                    var existingCategory = _context.AsportoCategories
                        .Where(c => c.CategoryName.ToLower() == model.CategoryName).FirstOrDefault();

                    if (existingCategory != null)
                    {
                        return Json(new { success = false, message = "La categoria esiste già." });
                    }  // Determine the next OrderId
                    int nextOrderId = 1; // Default to 1 if this is the first entry
                    var highestOrderId = _context.AsportoCategories.Max(c => (int?)c.OrderId);
                    if (highestOrderId.HasValue)
                    {
                        nextOrderId = highestOrderId.Value + 1;
                    }

                    // Set the OrderId for the new category
                    model.OrderId = nextOrderId;
                    _context.AsportoCategories.Add(model);
                    _context.SaveChanges();

                    return Json(new { success = true, message = "Categoria aggiunta correttamente." });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
                }
            }
            //return Json(new { success = false, message = "Invalid data received." });
        //}

        [HttpPost]
        public IActionResult EditAsportoCategory(AsportoCategory model)
        {
           
                try
                {
                    var existingCategory = _context.AsportoCategories.Find(model.CategoryID);

                    if (existingCategory == null)
                    {
                        return Json(new { success = false, message ="Categoria non trovata." });
                    }

                    existingCategory.CategoryName = model.CategoryName;
                    existingCategory.CategoryNameEnglish = model.CategoryNameEnglish;
                    existingCategory.CategoryNameSpanish = model.CategoryNameSpanish;
                    existingCategory.CategoryNameFrance = model.CategoryNameFrance;
                    existingCategory.CategoryNameGermany = model.CategoryNameGermany;
                    _context.AsportoCategories.Update(existingCategory);
                    _context.SaveChanges();

                    return Json(new { success = true, message = "Categoria aggiornata correttamente." });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
                }
            }
          

        [HttpDelete]
        public IActionResult DeleteAsportoCategory(int id)
        {
            try
            {
                var category = _context.AsportoCategories.Find(id);
                if (category == null)
                {
                    return Json(new { success = false, message ="Categoria non trovata." });
                }

                _context.AsportoCategories.Remove(category);
                _context.SaveChanges();

                return Json(new { success = true, message = "Categoria eliminata correttamente." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
            }
        }

        [HttpPost]
        public IActionResult AddAsportoItem(AsportoItem model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existingItem = _context.AsportoItems
                        .FirstOrDefault(i => i.ItemName == model.ItemName);
                    if (existingItem != null)
                    {
                        return Json(new { success = false, message ="L'articolo esiste già." });
                    }
                    // Determine the next OrderId for the new item in the given category
                    int nextOrderId = 1; // Default to 1 if no items exist in the category
                    var highestOrderId = _context.AsportoItems
                        .Where(i => i.CategoryID == model.CategoryID)
                        .Max(i => (int?)i.OrderId); // Get the highest OrderId in this category

                    if (highestOrderId.HasValue)
                    {
                        nextOrderId = highestOrderId.Value + 1;
                    }

                    // Set the OrderId for the new item
                    model.OrderId = nextOrderId;
                    _context.AsportoItems.Add(model);
                    _context.SaveChanges();

                    return Json(new { success = true, message = "Articolo aggiunto correttamente." });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
                }
            }
            return Json(new { success = false, message = "Invalid data received." });
        }

        [HttpPost]
        public IActionResult EditAsportoItem(AsportoItem model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var item = _context.AsportoItems
                        .FirstOrDefault(i => i.ItemID == model.ItemID);

                    if (item == null)
                    {
                        return Json(new { success = false, message = "Articolo non trovato." });
                    }

                    item.ItemName = model.ItemName;
                    item.Subtext = model.Subtext;
                    item.ItemPrice = model.ItemPrice;
                    item.Allergens = model.Allergens;

                    item.ItemNameEnglish = model.ItemNameEnglish;
                    item.SubtextEnglish = model.SubtextEnglish;
                    item.ItemPriceEnglish = model.ItemPriceEnglish;

                    item.ItemNameSpanish = model.ItemNameSpanish;
                    item.SubtextSpanish = model.SubtextSpanish;
                    item.ItemPriceSpanish = model.ItemPriceSpanish;

                    item.ItemNameFrance = model.ItemNameFrance;
                    item.SubtextFrance = model.SubtextFrance;
                    item.ItemPriceFrance = model.ItemPriceFrance;

                    item.ItemNameGermany = model.ItemNameGermany;
                    item.SubtextGermany = model.SubtextGermany;
                    item.ItemPriceGermany = model.ItemPriceGermany;



                    _context.AsportoItems.Update(item);
                    _context.SaveChanges();

                    return Json(new { success = true, message = "Articolo aggiornato correttamente." });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
                }
            }
            return Json(new { success = false, message = "Invalid data received." });
        }

        [HttpDelete]
        public IActionResult RemoveAsportoItem(int ItemID)
        {
            try
            {
                var item = _context.AsportoItems
                    .FirstOrDefault(i => i.ItemID == ItemID);

                if (item == null)
                {
                    return Json(new { success = false, message = "Articolo non trovato." });
                }

                _context.AsportoItems.Remove(item);
                _context.SaveChanges();

                return Json(new { success = true, message = "Articolo rimosso con successo." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
            }
        }
        [HttpPost]
        public IActionResult toggleAsportoAvailability(int ItemID, bool IsAvailable)
        {
            try
            {
                var item = _context.AsportoItems
                    .FirstOrDefault(i => i.ItemID == ItemID);

                if (item == null)
                {
                    return Json(new { success = false, message = "Articolo non trovato." });
                }
                item.IsAvailable = IsAvailable;
                _context.AsportoItems.Update(item);
                _context.SaveChanges();

                return Json(new { success = true, message = "Operazione riuscita." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
            }
        }

        #endregion
        #region Bevande
        [HttpPost]
        public IActionResult AddBevandeCategory(BevandeCategory model)
        {
            
                try
                {
                    var existingCategory = _context.BevandeCategories
                        .Where(c => c.CategoryName.ToLower() == model.CategoryName).FirstOrDefault();

                    if (existingCategory != null)
                    {
                        return Json(new { success = false, message = "La categoria esiste già." });
                    }  // Determine the next OrderId
                    int nextOrderId = 1; // Default to 1 if this is the first entry
                    var highestOrderId = _context.BevandeCategories.Max(c => (int?)c.OrderId);
                    if (highestOrderId.HasValue)
                    {
                        nextOrderId = highestOrderId.Value + 1;
                    }

                    // Set the OrderId for the new category
                    model.OrderId = nextOrderId;
                    _context.BevandeCategories.Add(model);
                    _context.SaveChanges();

                    return Json(new { success = true, message = "Categoria aggiunta correttamente." });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
                }
            }
          

        [HttpPost]
        public IActionResult EditBevandeCategory(BevandeCategory model)
        {
            
                try
                {
                    var existingCategory = _context.BevandeCategories.Find(model.CategoryID);

                    if (existingCategory == null)
                    {
                        return Json(new { success = false, message ="Categoria non trovata." });
                    }

                    existingCategory.CategoryName = model.CategoryName;
                    existingCategory.CategoryNameEnglish = model.CategoryNameEnglish;
                    existingCategory.CategoryNameSpanish = model.CategoryNameSpanish;
                    existingCategory.CategoryNameFrance = model.CategoryNameFrance;
                    existingCategory.CategoryNameGermany = model.CategoryNameGermany;
                    _context.BevandeCategories.Update(existingCategory);
                    _context.SaveChanges();

                    return Json(new { success = true, message = "Categoria aggiornata correttamente." });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
                }
            }
          

        [HttpDelete]
        public IActionResult DeleteBevandeCategory(int id)
        {
            try
            {
                var category = _context.BevandeCategories.Find(id);
                if (category == null)
                {
                    return Json(new { success = false, message ="Categoria non trovata." });
                }

                _context.BevandeCategories.Remove(category);
                _context.SaveChanges();

                return Json(new { success = true, message = "Categoria eliminata correttamente." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
            }
        }

        [HttpPost]
        public IActionResult AddBevandeItem(BevandeItem model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existingItem = _context.BevandeItems
                        .FirstOrDefault(i => i.ItemName == model.ItemName);
                    if (existingItem != null)
                    {
                        return Json(new { success = false, message ="L'articolo esiste già." });
                    }
                    // Determine the next OrderId for the new item in the given category
                    int nextOrderId = 1; // Default to 1 if no items exist in the category
                    var highestOrderId = _context.BevandeItems
                        .Where(i => i.CategoryID == model.CategoryID)
                        .Max(i => (int?)i.OrderId); // Get the highest OrderId in this category

                    if (highestOrderId.HasValue)
                    {
                        nextOrderId = highestOrderId.Value + 1;
                    }

                    // Set the OrderId for the new item
                    model.OrderId = nextOrderId;
                    _context.BevandeItems.Add(model);
                    _context.SaveChanges();

                    return Json(new { success = true, message = "Articolo aggiunto correttamente." });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
                }
            }
            return Json(new { success = false, message = "Invalid data received." });
        }

        [HttpPost]
        public IActionResult EditBevandeItem(BevandeItem model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var item = _context.BevandeItems
                        .FirstOrDefault(i => i.ItemID == model.ItemID);

                    if (item == null)
                    {
                        return Json(new { success = false, message = "Articolo non trovato." });
                    }

                    item.ItemName = model.ItemName;
                    item.Subtext = model.Subtext;
                    item.ItemPrice = model.ItemPrice;
                    item.Allergens = model.Allergens;

                    item.ItemNameEnglish = model.ItemNameEnglish;
                    item.SubtextEnglish = model.SubtextEnglish;
                    item.ItemPriceEnglish = model.ItemPriceEnglish;

                    item.ItemNameSpanish = model.ItemNameSpanish;
                    item.SubtextSpanish = model.SubtextSpanish;
                    item.ItemPriceSpanish = model.ItemPriceSpanish;

                    item.ItemNameFrance = model.ItemNameFrance;
                    item.SubtextFrance = model.SubtextFrance;
                    item.ItemPriceFrance = model.ItemPriceFrance;

                    item.ItemNameGermany = model.ItemNameGermany;
                    item.SubtextGermany = model.SubtextGermany;
                    item.ItemPriceGermany = model.ItemPriceGermany;



                    _context.BevandeItems.Update(item);
                    _context.SaveChanges();

                    return Json(new { success = true, message = "Articolo aggiornato correttamente." });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
                }
            }
            return Json(new { success = false, message = "Invalid data received." });
        }

        [HttpDelete]
        public IActionResult RemoveBevandeItem(int ItemID)
        {
            try
            {
                var item = _context.BevandeItems
                    .FirstOrDefault(i => i.ItemID == ItemID);

                if (item == null)
                {
                    return Json(new { success = false, message = "Articolo non trovato." });
                }

                _context.BevandeItems.Remove(item);
                _context.SaveChanges();

                return Json(new { success = true, message = "Articolo rimosso con successo." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
            }
        }
        [HttpPost]
        public IActionResult toggleBevandeAvailability(int ItemID, bool IsAvailable)
        {
            try
            {
                var item = _context.BevandeItems
                    .FirstOrDefault(i => i.ItemID == ItemID);

                if (item == null)
                {
                    return Json(new { success = false, message = "Articolo non trovato." });
                }
                item.IsAvailable = IsAvailable;
                _context.BevandeItems.Update(item);
                _context.SaveChanges();

                return Json(new { success = true, message = "Operazione riuscita." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
            }
        }

        #endregion
        #region Wine Module
        [HttpPost]
        public IActionResult AddWineCategory(WineCategory model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existingCategory = _context.WineCategories
                        .Where(c => c.CategoryName.ToLower() == model.CategoryName.ToLower()).FirstOrDefault();

                    if (existingCategory != null)
                    {
                        return Json(new { success = false, message = "La categoria esiste già." });
                    }
                    int nextOrderId = 1; // Default to 1 if this is the first entry
                    var highestOrderId = _context.WineCategories.Max(c => (int?)c.OrderBy);
                    if (highestOrderId.HasValue)
                    {
                        nextOrderId = highestOrderId.Value + 1;
                    }

                    // Set the OrderId for the new category
                    model.OrderBy = nextOrderId;
                    _context.WineCategories.Add(model);
                    _context.SaveChanges();

                    return Json(new { success = true, message = "Categoria aggiunta correttamente." });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
                }
            }
            return Json(new { success = false, message = "Invalid data received." });
        }

        [HttpPost]
        public IActionResult EditWineCategory(WineCategory model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existingCategory = _context.WineCategories.Find(model.CategoryID);

                    if (existingCategory == null)
                    {
                        return Json(new { success = false, message ="Categoria non trovata." });
                    }

                    existingCategory.CategoryName = model.CategoryName;
                    _context.WineCategories.Update(existingCategory);
                    _context.SaveChanges();

                    return Json(new { success = true, message = "Categoria aggiornata correttamente." });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
                }
            }
            return Json(new { success = false, message = "Invalid data received." });
        }
        [HttpDelete]
        public IActionResult DeleteWineCategory(int id)
        {
            try
            {
                var category = _context.WineCategories.Find(id);
                if (category == null)
                {
                    return Json(new { success = false, message ="Categoria non trovata." });
                }

                _context.WineCategories.Remove(category);
                _context.SaveChanges();

                return Json(new { success = true, message = "Categoria eliminata correttamente." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
            }
        }

        [HttpPost]
        public IActionResult AddWineSubcategory(WineSubcategory model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existingSubcategory = _context.WineSubcategories
                        .Where(sc => sc.SubcategoryName.ToLower() == model.SubcategoryName.ToLower()
                                     && sc.CategoryID == model.CategoryID).FirstOrDefault();

                    if (existingSubcategory != null)
                    {
                        return Json(new { success = false, message = "La sottocategoria esiste già." });
                    }
                    // Determine the next OrderId for the new item in the given category
                    int nextOrderId = 1; // Default to 1 if no items exist in the category
                    var highestOrderId = _context.WineSubcategories
                        .Where(i => i.CategoryID == model.CategoryID)
                        .Max(i => (int?)i.OrderBy); // Get the highest OrderId in this category

                    if (highestOrderId.HasValue)
                    {
                        nextOrderId = highestOrderId.Value + 1;
                    }

                    // Set the OrderId for the new item
                    model.OrderBy = nextOrderId;
                    _context.WineSubcategories.Add(model);
                    _context.SaveChanges();

                    return Json(new { success = true, message = "Sottocategoria aggiunta correttamente." });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
                }
            }
            return Json(new { success = false, message = "Invalid data received." });
        }

        [HttpPost]
        public IActionResult EditWineSubcategory(WineSubcategory model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existingSubcategory = _context.WineSubcategories.Find(model.SubcategoryID);

                    if (existingSubcategory == null)
                    {
                        return Json(new { success = false, message = "Subcategory not found." });
                    }

                    existingSubcategory.SubcategoryName = model.SubcategoryName;
                    existingSubcategory.CategoryID = model.CategoryID;

                    _context.WineSubcategories.Update(existingSubcategory);
                    _context.SaveChanges();

                    return Json(new { success = true, message = "Sottocategoria aggiornata correttamente." });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
                }
            }
            return Json(new { success = false, message = "Invalid data received." });
        }

        [HttpDelete]
        public IActionResult DeleteWineSubcategory(int id)
        {
            try
            {
                var subcategory = _context.WineSubcategories.Find(id);
                if (subcategory == null)
                {
                    return Json(new { success = false, message = "Subcategory not found." });
                }

                _context.WineSubcategories.Remove(subcategory);
                _context.SaveChanges();

                return Json(new { success = true, message = "Sottocategoria eliminata correttamente." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
            }
        }

        [HttpPost]
        public IActionResult AddWineItem(WineItem model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existingItem = _context.WineItems
                        .FirstOrDefault(i => i.ItemName.ToLower() == model.ItemName.ToLower()
                                             && i.SubcategoryID == model.SubcategoryID);

                    if (existingItem != null)
                    {
                        return Json(new { success = false, message ="L'articolo esiste già." });
                    }
                    // Determine the next OrderId for the new item in the given category
                    int nextOrderId = 1; // Default to 1 if no items exist in the category
                    var highestOrderId = _context.WineItems
                        .Where(i => i.SubcategoryID == model.SubcategoryID)
                        .Max(i => (int?)i.OrderBy); // Get the highest OrderId in this category

                    if (highestOrderId.HasValue)
                    {
                        nextOrderId = highestOrderId.Value + 1;
                    }

                    // Set the OrderId for the new item
                    model.OrderBy = nextOrderId;
                    _context.WineItems.Add(model);
                    _context.SaveChanges();

                    return Json(new { success = true, message = "Articolo aggiunto correttamente." });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
                }
            }
            return Json(new { success = false, message = "Invalid data received." });
        }

        [HttpPost]
        public IActionResult EditWineItem(WineItem model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existingItem = _context.WineItems.Find(model.ItemID);

                    if (existingItem == null)
                    {
                        return Json(new { success = false, message = "Articolo non trovato." });
                    }

                    existingItem.ItemName = model.ItemName;
                    existingItem.ItemPrice = model.ItemPrice;
                    _context.WineItems.Update(existingItem);
                    _context.SaveChanges();

                    return Json(new { success = true, message = "Articolo aggiornato correttamente." });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
                }
            }
            return Json(new { success = false, message = "Invalid data received." });
        }

        [HttpDelete]
        public IActionResult RemoveWineItem(int ItemID)
        {
            try
            {
                var item = _context.WineItems.Find(ItemID);

                if (item == null)
                {
                    return Json(new { success = false, message = "Articolo non trovato." });
                }

                _context.WineItems.Remove(item);
                _context.SaveChanges();

                return Json(new { success = true, message = "Articolo rimosso con successo." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
            }
        }

        [HttpPost]
        public IActionResult ToggleWineAvailability(int ItemID, bool IsAvailable)
        {
            try
            {
                var item = _context.WineItems.Find(ItemID);

                if (item == null)
                {
                    return Json(new { success = false, message = "Articolo non trovato." });
                }

                item.IsAvailable = IsAvailable;
                _context.WineItems.Update(item);
                _context.SaveChanges();

                return Json(new { success = true, message ="Operazione riuscita." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
            }
        }

        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
