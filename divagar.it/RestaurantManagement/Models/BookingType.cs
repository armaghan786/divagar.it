using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Models
{
    public class BookingType
    {
        [Key]
        public int BookingTypeId { get; set; }
        [DisplayName("Booking Type")]
        public string BookingTypee { get; set; }
        [DisplayName("No Of Tables")]
        public int NoOfTables { get; set; }
        [DisplayName("No Of Seats")]
        public int NoOfSeats { get; set; }
    }
}
