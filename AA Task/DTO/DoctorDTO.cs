using AA_Task.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace AA_Task.DTO
{
    public class DoctorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string phoneNumber { get; set; }
        public string BirthDate { get; set; }
        public int doctorspecialtyId { get; set; }
        public string City { get; set; }
        public string universiry { get; set; }
        public string? ProfilePic { get; set; }
        public int fee { get; set; }
        public float rating { get; set; }
        public string location { get; set; }

        public IFormFile Image { get; set; }
    }
}
