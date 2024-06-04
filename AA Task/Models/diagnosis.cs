namespace AA_Task.Models
{
    public class diagnosis
    {
        public int id { get; set; }
        public int ApponitmentId { get; set; }
        public int UserId { get; set; }
        public int doctorId { get; set; }
        public string summaryOfTheSession { get; set; }
        public string mainDiseases { get; set; }
        public string datetime { get; set; }
    }
}
