﻿using Microsoft.AspNetCore.Mvc;

namespace RestaurantManagement.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
