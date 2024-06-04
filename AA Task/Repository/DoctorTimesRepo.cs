using AA_Task.DataContext;
using AA_Task.Interface;
using BookingPage.Models;

namespace AA_Task.Repository
{
    public class DoctorTimesRepo : IdoctorTimes
    {
        private readonly TaskDataContext _Context;
        public DoctorTimesRepo(TaskDataContext context)
        {
            _Context = context;
        }
        public bool addDoctortimes(DoctorTimes doctorTimes)
        {
            DoctorTimes doctortime =_Context.doctorTimes.Where(d=>d.DoctorId==doctorTimes.DoctorId&&d.TimeId==doctorTimes.TimeId&&d.datetime==doctorTimes.datetime).FirstOrDefault();
            if (doctortime != null)
            {
                return false;
            }
            else
            {
                _Context.doctorTimes.Add(doctorTimes);
                return _Context.SaveChanges()>0?true:false;
            }
        }

        public bool deleteDoctorTime(int DoctorTimeId)
        {
            DoctorTimes time = _Context.doctorTimes.Find(DoctorTimeId);
            _Context.doctorTimes.Remove(time);
            return _Context.SaveChanges()>0?true:false;
        }

        public bool deleteTimesForDoctor(int doctorId)
        {
            
            List<DoctorTimes> doctorTimes=_Context.doctorTimes.Where(t=>t.DoctorId==doctorId).ToList();
            
                foreach (DoctorTimes t in doctorTimes)
            {
                Appointments app = _Context.appointments.Where(a => a.timeid == t.TimeId && a.doctorid == t.DoctorId&&a.appointmentTime==t.datetime).FirstOrDefault();
                if(app!=null)
                {

                }
                else
                {
                    _Context.doctorTimes.Remove(t);
                }
            }
            return _Context.SaveChanges()>0?true:false;
            
        }
    }
}
