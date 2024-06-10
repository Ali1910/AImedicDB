namespace AA_Task.Models
{
    public class RatingAndComments
    {
        public int Id { get; set; }
        public  int DoctorId { get; set; }
        public int UserId { get; set; }
        public int ApponintmetId { get; set; }
        public string?  commment { get; set; }
        public  string Rating { get; set; }
    }
}
