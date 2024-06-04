using System.ComponentModel.DataAnnotations.Schema;

namespace BookingPage.Models
{
        public class Appointments
        {

        public int Id { get; set; }
        public int userid { get; set; }
        public int doctorid { get; set; }
        public int timeid { get; set; }
        public string appointmentTime { get; set; }
        public bool Done { get; set; }
        public bool Canceled { get; set; }
        public bool rated { get; set; }


    }
}
