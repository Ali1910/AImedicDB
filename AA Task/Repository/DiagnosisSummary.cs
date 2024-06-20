using AA_Task.DataContext;
using AA_Task.Interface;
using AA_Task.Models;
using BookingPage.Models;
using school;

namespace AA_Task.Repository
{
    public class DiagnosisSummary : IdiagnosisSummary
    {
        private readonly TaskDataContext _context;
        public DiagnosisSummary(TaskDataContext context,IAppointmentRepository repo)
        {
            _context = context;
         
        }
        public bool addDiagnoses(diagnosis diagnosis)
        {
            diagnosis checker=_context.diagnosesSummary.Where(d=>d.ApponitmentId==diagnosis.ApponitmentId).FirstOrDefault()!;
            if (checker == null)
            {
                diagnosis diagnosis1 = new diagnosis()
                {
                    doctorId = diagnosis.doctorId,
                    UserId = diagnosis.UserId,
                    summaryOfTheSession = diagnosis.summaryOfTheSession,
                    ApponitmentId = diagnosis.ApponitmentId,
                    mainDiseases = diagnosis.mainDiseases,
                    datetime = diagnosis.datetime,
                };
                _context.diagnosesSummary.Add(diagnosis1);
                var app = _context.appointments.Find(diagnosis1.ApponitmentId);
                app.Done = true;
                _context.appointments.Update(app);
                return _context.SaveChanges() > 0 ? true : false;

            }
            else
            {
                return false;
            }
            
          
            
        }

        public bool deleteDiagnosis(int diagnosisId)
        {
           diagnosis dig = _context.diagnosesSummary.Find(diagnosisId)!;
           Appointments app= _context.appointments.Find(dig.ApponitmentId)!;
            app.Done = false;
            _context.appointments.Update(app);
            _context.diagnosesSummary.Remove(dig);
            return _context.SaveChanges()>0?true:false;

        }

        public Dictionary<string,dynamic> GetDiagnosesForDoctor(int doctorId)
        {
           List<diagnosis> diagnoses=_context.diagnosesSummary.OrderByDescending(d=>d.id).Where(d=>d.doctorId==doctorId).ToList();
            List<User> users = new List<User>();
            foreach (var item in diagnoses)
            {
                User user = _context.users.Find(item.UserId);
                users.Add(user);
            }
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            response.Add("diagnosis", diagnoses);
            response.Add("user", users);
            return response;
        }

        public List<diagnosis> GetDiagnosesForUser(int userId)
        {
            List<diagnosis> response = _context.diagnosesSummary.OrderByDescending(d => d.id).Where(d => d.UserId == userId).ToList();
            return response;
        }
    }
}
