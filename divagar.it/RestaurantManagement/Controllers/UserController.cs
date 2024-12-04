using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Models;

namespace RestaurantManagement.Controllers
{
	public class UserController : Controller
	{
		private RestaurantContext _context;
        public UserController(RestaurantContext restaurantContext)
        {
			_context = restaurantContext;
        }
        public IActionResult Index(string id, bool isconfirmed)
		{
            if (!string.IsNullOrEmpty(id))
            {
                var user = _context.ApplicationUsers.FirstOrDefault(x => x.Id == id);
                if (user != null)
                {
                    user.EmailConfirmed = isconfirmed;
                }
            }
            var users = _context.ApplicationUsers.ToList();
			return View(users);
		}
       
    }
}
