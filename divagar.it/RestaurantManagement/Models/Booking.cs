using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Models
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }
        public int NoOfGuest { get; set; }
        public int Children { get; set; }
        public int Adults { get; set; }
        public DateTime BookingDate { get; set; }
        public TimeOnly StartTime { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneExtention { get; set; }
        public string PhoneNo { get; set; }
        public string? Notes { get; set; }
        public bool GuaranteeNone { get; set; }
        public bool Guaranteelactose { get; set; }
        public bool GuaranteeGulten { get; set; }
        public bool Guaranteecrustaceans { get; set; }
        public bool Guaranteevegetarian { get; set; }
        public bool Guaranteepescetarian { get; set; }
        public string GuaranteeNotes { get; set; }
        public bool Authorize { get; set; }
        public bool AuthorizeOne { get; set; }
        public bool AuthorizeTwo { get; set; }
        public bool AuthorizeThree { get; set; }
        public bool AuthorizeFour { get; set; }
    }
}
