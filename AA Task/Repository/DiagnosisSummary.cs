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
            diagnosis diagnosis1 = new diagnosis()
            {
                doctorId = diagnosis.doctorId,
                UserId = diagnosis.UserId,
                summaryOfTheSession = diagnosis.summaryOfTheSession,
                ApponitmentId=diagnosis.ApponitmentId,
                mainDiseases=diagnosis.mainDiseases,
                datetime=diagnosis.datetime,
            };
                _context.diagnosesSummary.Add(diagnosis1);
            var app = _context.appointments.Find(diagnosis1.ApponitmentId);
            app.Done=true;
            _context.appointments.Update(app);
                return _context.SaveChanges() > 0 ? true : false;
          
            
        }
    }
}
