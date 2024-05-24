namespace AA_Task.Models
{
    public class RatingAndComments
    {
        public int id { get; set; }
        public string comment { get; set; }
        public float rating { get; set; }
        public  int  doctorId { get; set; }
        public  int UserId { get; set; }
        public int appointmentId { get; set; }
    }
}
