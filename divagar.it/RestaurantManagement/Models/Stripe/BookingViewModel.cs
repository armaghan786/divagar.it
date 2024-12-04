namespace RestaurantManagement.Models.Stripe
{
    public class BookingViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Allergies { get; set; }
        public string Notes { get; set; }
        public int NumberOfPeople { get; set; }
        public string StripeToken { get; set; }
    }
}
