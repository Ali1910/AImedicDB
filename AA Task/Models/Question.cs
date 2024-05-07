namespace AA_Task.Models
{
    public class Question
    {
        public int Id   { get; set; }
        public string content { get; set; }
        public int User { get; set; }
        public bool Answered { get; set; }

    }
}
