using System.ComponentModel.DataAnnotations.Schema;

namespace BookingPage.Models
{
    public class DoctorTimes
    {
        public int Id { get; set; }
        public int TimeId { get; set; }
        public int DoctorId { get; set; }
        public string datetime { get; set; }
        public bool empty { get; set; }
       
    }
}
