using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RestaurantManagement.Models;
using RestaurantManagement.Models.Stripe;
using Stripe;

namespace RestaurantManagement.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly StripeSettings _stripeSettings;

        public PaymentsController(IOptions<StripeSettings> stripeSettings)
        {
            _stripeSettings = stripeSettings.Value;
            StripeConfiguration.ApiKey = _stripeSettings.SecretKey;
        }

        [HttpGet]
        public IActionResult CreateBooking()
        {
            ViewBag.PublishedKey = _stripeSettings.PublishableKey;
            return View(new BookingViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(BookingViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var customerOptions = new CustomerCreateOptions
            {
                Name = model.FirstName + " " + model.LastName,
                Email = model.Email,
            };
            var customerService = new CustomerService();
            var customer = await customerService.CreateAsync(customerOptions);

            var amount = model.NumberOfPeople * 20;

            var paymentIntentOptions = new PaymentIntentCreateOptions
            {
                Amount = amount * 100,
                Currency = "eur",
                Customer = customer.Id,
                PaymentMethod = model.StripeToken,
                CaptureMethod = "manual",
                ConfirmationMethod = "manual",
                //Confirm = true,
            };

            var paymentIntentService = new PaymentIntentService();
            var paymentIntent = await paymentIntentService.CreateAsync(paymentIntentOptions);

            return RedirectToAction("BookingConfirmation");
        }
        public IActionResult BookingConfirmation()
        {
            return View();
        }
    }
}
