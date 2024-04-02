
using AA_Task.DataContext;
using AA_Task.DTO;
using AA_Task.Models;
using BookingPage.Models;


namespace school.repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly TaskDataContext _context;
        public AppointmentRepository(TaskDataContext context)
        {
            _context = context;
        }


        public bool addAppointment(string appointmentime, int timeid, int UserId, int doctorId)
        {
            
            var userChecker = _context.userTimes.Where(b => b.Timekey == timeid && b.userKey == UserId&& b.Time==appointmentime).FirstOrDefault();
            var DoctorChecker = _context.doctorTimes.Where(b => b.TimeId == timeid && b.DoctorId == doctorId&&b.datetime==appointmentime).FirstOrDefault();
            if (userChecker == null && DoctorChecker.empty)
            {
                var appointment = new Appointments
                {
                    doctorid = doctorId,
                    userid = UserId,
                    timeid = timeid,
                    appointmentTime= appointmentime,
                };
                _context.appointments.Add(appointment);
                var Usertime = new UserTimes
                {
                    userKey = UserId,
                    Timekey = timeid,
                    Time=appointmentime,
                    empty = false
                };

                DoctorChecker.empty = false;
                _context.userTimes.Add(Usertime);
                return _context.SaveChanges() > 0 ? true : false;
            }
            else
            {
                return false;
            }
        }

        public List<AppointmenstDTO> GetUserAppointments(int userId,bool state)
        {
            List<Appointments> appointmentsForUser = _context.appointments.OrderByDescending(b => b.Id).Where(a => a.userid == userId&&a.Canceled== state).ToList() ?? [];
            List<AppointmenstDTO> UserAppointments = [];
            foreach (var item in appointmentsForUser)
            {
                Doctor doctor = _context.doctors.Where(d => d.Id == item.doctorid).FirstOrDefault();
                Times time = _context.times.Where(d => d.Id == item.timeid).FirstOrDefault();
                AppointmenstDTO UserAppointment = new AppointmenstDTO()
                {
                    id = item.Id,
                    doctorid = item.doctorid,
                    timeid = item.timeid,
                    userid = userId,
                    doctorspec = _context.specialties.Where(b => b.Id == doctor.doctorspecialtyId).FirstOrDefault().Name,
                    doctorpic = doctor.ProfilePic,
                    doctoNum = doctor.phoneNumber,
                    day = time.day,
                    year = time.year,
                    month = time.month,
                    doctorname = doctor.Name,
                    AppointmentTime = item.appointmentTime
                };
                UserAppointments.Add(UserAppointment);
            }

            
            return UserAppointments;
        }

      

        public List<DoctorTimes> getDoctorTimesforDate(int doctorId, string year, string month, string day)
        {
            int DateId = _context.times.Where(b => b.year == year && b.day == day && b.month == month).FirstOrDefault().Id;
            List<DoctorTimes> getdate = _context.doctorTimes.Where(b => b.DoctorId == doctorId && b.TimeId == DateId).ToList() ?? [];
            return getdate;
        }

        public bool deleteAppointment(int AppointmentId)
        {
            Appointments appointmnet = _context.appointments.Find(AppointmentId);
            DoctorTimes doctorTime=_context.doctorTimes.Where(DT=> DT.DoctorId == appointmnet.doctorid && DT.TimeId==appointmnet.timeid && DT.datetime == appointmnet.appointmentTime).FirstOrDefault();
            UserTimes userTime= _context.userTimes.Where(DT => DT.userKey == appointmnet.userid && DT.Timekey == appointmnet.timeid && DT.Time == appointmnet.appointmentTime).FirstOrDefault();
            appointmnet.Canceled = true;
            doctorTime.empty = true;
            _context.userTimes.Remove(userTime);

            return _context.SaveChanges()>0?true:false;
        }



        

        public bool UpdateAppointment(string year, string day, string month, int AppointmentId, string appointmentime)
        {
            Appointments oldAppointment = _context.appointments.Where(b => b.Id == AppointmentId).FirstOrDefault();
            UserTimes oldUserApp = _context.userTimes.Where(b => b.Timekey == oldAppointment.timeid && b.userKey == oldAppointment.userid&&b.Time==oldAppointment.appointmentTime).FirstOrDefault();
            DoctorTimes oldDoctorApp = _context.doctorTimes.Where(b => b.TimeId == oldAppointment.timeid && b.DoctorId == oldAppointment.doctorid && b.datetime == oldAppointment.appointmentTime).FirstOrDefault();
            Times Newtime = _context.times.Where(b => b.year == year && b.day == day && b.month == month).FirstOrDefault();
            DoctorTimes NewDoctorApp = _context.doctorTimes.Where(b => b.TimeId == Newtime.Id && b.DoctorId == oldAppointment.doctorid&&b.datetime==appointmentime).FirstOrDefault();
            UserTimes newUserApp = _context.userTimes.Where(u=>u.Id==oldAppointment.userid&&u.Timekey==Newtime.Id&&u.Time==appointmentime).FirstOrDefault();
            if (NewDoctorApp.empty)
            {
                if(newUserApp!=null)
                {
                    return false;
                }
                else
                {
                    oldUserApp.Timekey = Newtime.Id;
                    oldUserApp.Time = appointmentime;
                    oldAppointment.timeid = Newtime.Id;
                    oldAppointment.appointmentTime = appointmentime;
                    oldDoctorApp.empty = true;
                    NewDoctorApp.empty = false;

                }
          

            }

            return _context.SaveChanges() > 0 ? true : false;
        }
    }
}

