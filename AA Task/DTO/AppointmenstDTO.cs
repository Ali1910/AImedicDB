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
        public string  doctorpic { get; set; }
        public string doctorname   { get; set; }
        public string doctoNum { get; set; }
        public string  doctorspec { get; set; }
    }
}
