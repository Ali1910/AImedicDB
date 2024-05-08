namespace AA_Task.DTO
{
    public class AppointmenstDTO
    {
        public int id { get; set; }
        public int doctorid { get; set; }
        public int userid  { get; set; }
        public int timeid { get; set; }
        public string year { get; set; }
        public string month { get; set; }   
        public string day { get; set; }
        public string AppointmentTime { get; set; }
        public string  pic { get; set; }
        public string name   { get; set; }
        public string number { get; set; }
        public string?  spec { get; set; }
        public int? fee { get; set; }
        public string? unviersity { get; set; }
    }
}
