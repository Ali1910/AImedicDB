using System.ComponentModel.DataAnnotations.Schema;

namespace AA_Task.Models
{
    public class User
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string gender { get; set; }
        public string phoneNumber { get; set; }
        public string BirthDate { get; set; }
        public string? SpecialCondition { get; set; }
        public string? ProfilePic { get; set; }
        public  string?  NFCId { get; set; }
        public string City { get; set; }
        
   
    }
}
