
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
            
            UserTimes userChecker = _context.userTimes.Where(b => b.Timekey == timeid && b.userKey == UserId&& b.Time==appointmentime).FirstOrDefault()!;
            DoctorTimes DoctorChecker = _context.doctorTimes.Where(b => b.TimeId == timeid && b.DoctorId == doctorId&&b.datetime==appointmentime).FirstOrDefault()!;
            Times time = _context.times.Find(timeid)!;
            
            if (int.Parse(time.month) > DateTime.Now.Month) // next month no need to check day
            {
                return addingAppoinment(appointmentime, timeid, UserId, doctorId, userChecker, DoctorChecker);
            }
            else if(int.Parse(time.month) == DateTime.Now.Month) // same month check day
            {
                if (int.Parse(time.day) > DateTime.Now.Day) // next day no need to check hour
                {
                    return addingAppoinment(appointmentime, timeid, UserId, doctorId, userChecker, DoctorChecker);

                }
                else if (int.Parse(time.day) == DateTime.Now.Day) // same day need to check hour
                {
                  

                    if (int.Parse(appointmentime.Substring(0, 2)) - (DateTime.Now.Hour+1) > 0) // next hour no need to check minutes
                    {
                        return addingAppoinment(appointmentime, timeid, UserId, doctorId, userChecker, DoctorChecker);
                    }
                    else if ((DateTime.Now.Hour+1) - int.Parse(appointmentime.Substring(0, 2)) == 0) //same hour need to check minutes
                    {
                        
                        if (int.Parse(appointmentime.Substring(3, 2)) <= DateTime.Now.Minute) // passed or same minutes can't book
                        {
                            return false;
                        }

                        return addingAppoinment(appointmentime, timeid, UserId, doctorId, userChecker, DoctorChecker);// still minutes left

                    }
                    return false;//passed hour
                
                }
                return false;// passed day

            }
            else
            {
                return false;//passed month
            }
            
        }

        private bool addingAppoinment(string appointmentime, int timeid, int UserId, int doctorId, UserTimes userChecker, DoctorTimes DoctorChecker)
        {
            if (userChecker == null && DoctorChecker.empty)
            {
                var appointment = new Appointments
                {
                    doctorid = doctorId,
                    userid = UserId,
                    timeid = timeid,
                    appointmentTime = appointmentime,
                };
                _context.appointments.Add(appointment);
                var Usertime = new UserTimes
                {
                    userKey = UserId,
                    Timekey = timeid,
                    Time = appointmentime,
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
            List<Appointments> appointmentsForUser = _context.appointments.OrderByDescending(b => b.Id).Where(a => a.userid == userId&&a.Canceled== state&&a.Done==false).ToList() ?? [];
            List<AppointmenstDTO> UserAppointments = [];
            foreach (var item in appointmentsForUser)
            {
                Doctor doctor = _context.doctors.Find( item.doctorid)!;
                Times time = _context.times.Find(item.timeid)!;
                AppointmenstDTO UserAppointment = new AppointmenstDTO()
                {
                    id = item.Id,
                    doctorid = item.doctorid,
                    timeid = item.timeid,
                    userid = userId,
                    spec = _context.specialties.Find( doctor.doctorspecialtyId)!.Name,
                    pic = doctor.ProfilePic!,
                    number = doctor.phoneNumber,
                    day = time.day,
                    year = time.year,
                    month = time.month,
                    name = doctor.Name,
                    AppointmentTime = item.appointmentTime,
                    fee=doctor.fee,
                    unviersity=doctor.universiry,
                    rated=item.rated,
                    
                };
                UserAppointments.Add(UserAppointment);
            }

            
            return UserAppointments;
        }

      

        public List<DoctorTimes> getDoctorTimesforDate(int doctorId, string year, string month, string day)
        {
            int DateId = _context.times.Where(b => b.year == year && b.day == day && b.month == month).FirstOrDefault()!.Id;
            List<DoctorTimes> getdate = _context.doctorTimes.Where(b => b.DoctorId == doctorId && b.TimeId == DateId).ToList() ?? [];
            if (DateTime.Now.Month == int.Parse(month)) // same month
            {
                 
                if (DateTime.Now.Day > int.Parse(day)) // old day no need too check hour
                {
                    foreach (DoctorTimes dt in getdate)
                    {
                        dt.empty = false;
                    }
                    return getdate;
                }
                if (DateTime.Now.Day == int.Parse(day)) // same day check hour
                {
                    foreach (var dt in getdate)
                    {
                      
                        if (int.Parse(dt.datetime.Substring(0, 2)) < (DateTime.Now.Hour+1)) //checking hour no need to check minutes 
                        {
                            dt.empty = false;
                            

                        }else if(int.Parse(dt.datetime.Substring(0, 2)) == (DateTime.Now.Hour+1)) // checking hour and need to check minute
                        {
                            
                            if (int.Parse(dt.datetime.Substring(3, 2)) <= DateTime.Now.Minute) // old or same minutes
                            {
                                dt.empty = false;
                            }
                        }

                    }
                    return getdate;

                }

                return getdate;
            }
            else if(DateTime.Now.Month > int.Parse(month)) // old month no need to check day 
            {
                foreach (var item in getdate)
                {
                    item.empty = false;
                    

                }
                return getdate;
            }
            else // comming month
            {
                return getdate;
            }    
        }

        public bool deleteAppointment(int AppointmentId)
        {
            Appointments appointmnet = _context.appointments.Find(AppointmentId)!;
            DoctorTimes doctorTime = _context.doctorTimes.Where(DT => DT.DoctorId == appointmnet.doctorid && DT.TimeId == appointmnet.timeid && DT.datetime == appointmnet.appointmentTime).FirstOrDefault()!;
            UserTimes userTime = _context.userTimes.Where(DT => DT.userKey == appointmnet.userid && DT.Timekey == appointmnet.timeid && DT.Time == appointmnet.appointmentTime).FirstOrDefault()!;
            Times time = _context.times.Find(appointmnet.timeid)!;
            if (DateTime.Now.Month == int.Parse(time.month)) //same month needs to check day
            {
                if (int.Parse(time.day) - DateTime.Now.Day < 0)//old day no need to check hour
                {
                    return false;
                }else if (int.Parse(time.day) - DateTime.Now.Day == 0)// same day needs to check hour
                {
                    
                    
                    if (int.Parse(appointmnet.appointmentTime.Substring(0, 2)) - (DateTime.Now.Hour+1) <= 1)// hour diff is one or less
                    {
                        return false;
                    }
                    else // hour diff are more than hour 
                    {
                        appointmnet.Canceled = true;
                        doctorTime.empty = true;
                        _context.userTimes.Remove(userTime);
                        return _context.SaveChanges() > 0 ? true : false;

                    }
                }
                else//coming day
                {
                    appointmnet.Canceled = true;
                    doctorTime.empty = true;
                    _context.userTimes.Remove(userTime);
                    return _context.SaveChanges() > 0 ? true : false;
                }
                    
                
            }else if (DateTime.Now.Month > int.Parse(time.month))//old month
            {
                return false;
            }

            else// comming month
            {
                appointmnet.Canceled = true;
                doctorTime.empty = true;
                _context.userTimes.Remove(userTime);
                return _context.SaveChanges() > 0 ? true : false;
            }
            
            
        }
        public bool UpdateAppointment(int timeid,int AppointmentId, string appointmentime)
        {
            Appointments oldAppointment = _context.appointments.Where(b => b.Id == AppointmentId).FirstOrDefault()!;
            UserTimes oldUserApp = _context.userTimes.Where(b => b.Timekey == oldAppointment.timeid && b.userKey == oldAppointment.userid && b.Time == oldAppointment.appointmentTime).FirstOrDefault()!;
            DoctorTimes oldDoctorApp = _context.doctorTimes.Where(b => b.TimeId == oldAppointment.timeid && b.DoctorId == oldAppointment.doctorid && b.datetime == oldAppointment.appointmentTime).FirstOrDefault()!;
            DoctorTimes NewDoctorApp = _context.doctorTimes.Where(b => b.TimeId == timeid && b.DoctorId == oldAppointment.doctorid && b.datetime == appointmentime).FirstOrDefault()!;
            UserTimes newUserApp = _context.userTimes.Where(u => u.Id == oldAppointment.userid && u.Timekey == timeid && u.Time == appointmentime).FirstOrDefault()!;
            Times time = _context.times.Find(timeid);

            if (int.Parse(time.month) > DateTime.Now.Month) // next month no need to check day
            {
                return updateAppointment(timeid, appointmentime, oldAppointment, oldUserApp, oldDoctorApp, NewDoctorApp, newUserApp);
            }
            else if (int.Parse(time.month) == DateTime.Now.Month) // same month check day
            {
                if (int.Parse(time.day) > DateTime.Now.Day) // next day no need to check hour
                {
                    return updateAppointment(timeid, appointmentime, oldAppointment, oldUserApp, oldDoctorApp, NewDoctorApp, newUserApp);
                }
                else if (int.Parse(time.day) == DateTime.Now.Day) // same day need to check hour
                {
                   

                    if (int.Parse(appointmentime.Substring(0, 2)) - (DateTime.Now.Hour+1) > 0) // next hour no need to check minutes
                    {
                        return updateAppointment(timeid, appointmentime, oldAppointment, oldUserApp, oldDoctorApp, NewDoctorApp, newUserApp);
                    }
                    else if ((DateTime.Now.Hour+1) - int.Parse(appointmentime.Substring(0, 2)) == 0) //same hour need to check minutes
                    {
                      
                        if (int.Parse(appointmentime.Substring(3, 2)) <= DateTime.Now.Minute) // passed or same minutes can't book
                        {
                            return false;
                        }

                        return updateAppointment(timeid, appointmentime, oldAppointment, oldUserApp, oldDoctorApp, NewDoctorApp, newUserApp);// still minutes left

                    }
                    return false;//passed hour

                }
                return false;// passed day

            }
            else
            {
                return false;//passed month
            }


        }

        private bool updateAppointment(int timeid, string appointmentime, Appointments oldAppointment, UserTimes oldUserApp, DoctorTimes oldDoctorApp, DoctorTimes NewDoctorApp, UserTimes newUserApp)
        {
            if (NewDoctorApp!.empty && newUserApp == null)
            {


                oldUserApp.Timekey = timeid;
                oldUserApp.Time = appointmentime;
                oldAppointment.timeid = timeid;
                oldAppointment.appointmentTime = appointmentime;
                oldDoctorApp.empty = true;
                NewDoctorApp.empty = false;
                return _context.SaveChanges() > 0 ? true : false;



            }
            else
            {
                return false;
            }
        }

        public bool EndAppointment(int AppointmentId)
        {
            Appointments appointmnet = _context.appointments.Find(AppointmentId)!;
            DoctorTimes doctorTime = _context.doctorTimes.Where(DT => DT.DoctorId == appointmnet.doctorid && DT.TimeId == appointmnet.timeid && DT.datetime == appointmnet.appointmentTime).FirstOrDefault()!;
            UserTimes userTime = _context.userTimes.Where(DT => DT.userKey == appointmnet.userid && DT.Timekey == appointmnet.timeid && DT.Time == appointmnet.appointmentTime).FirstOrDefault()!;
            Times time = _context.times.Find(appointmnet.timeid)!;
            if (DateTime.Now.Month == int.Parse(time.month)) //same month needs to check day  for ex 5
            {
                if (int.Parse(time.day) - DateTime.Now.Day < 0)//old day no need to check hour  **past appointment** for ex day 4-5 يقدر يخليه done
                {
                    appointmnet.Done = true;
                    _context.userTimes.Remove(userTime);
                    return _context.SaveChanges() > 0 ? true : false;
                }
                else if (int.Parse(time.day) - DateTime.Now.Day == 0)// same day needs to check hour for ex day 5 لازم نشوف الساعة
                {
                   

                    if (int.Parse(appointmnet.appointmentTime.Substring(0, 2)) - (DateTime.Now.Hour+1) <= 1)// hour diff is one or more ***past appointment*** for ex 20-21
                    {
                        appointmnet.Done = true;
                        _context.userTimes.Remove(userTime);
                        return _context.SaveChanges() > 0 ? true : false;
                    }
                    else // hour diff are more than hour **PresentAppointment****  for ex 22-21
                    {
                        return false;

                    }
                }
                else//coming day for ex today is 5 and the appointment in 7
                {
                    return false;
                }


            }
            else if (DateTime.Now.Month > int.Parse(time.month))//old month
            {
                appointmnet.Done = true;
                _context.userTimes.Remove(userTime);
                return _context.SaveChanges() > 0 ? true : false;
            }

            else// comming month
            {
                return false;
            }
        }

        public List<AppointmenstDTO> GetUserDoneAppointments(int userId)
        {
            List<Appointments> appointmentsForUser = _context.appointments.OrderByDescending(b => b.Id).Where(a => a.userid == userId && a.Done == true).ToList() ?? [];
            List<AppointmenstDTO> UserAppointments = [];
            foreach (var item in appointmentsForUser)
            {
                Doctor doctor = _context.doctors.Find(item.doctorid)!;
                Times time = _context.times.Find(item.timeid)!;
                AppointmenstDTO UserAppointment = new AppointmenstDTO()
                {
                    id = item.Id,
                    doctorid = item.doctorid,
                    timeid = item.timeid,
                    userid = userId,
                    spec = _context.specialties.Find( doctor.doctorspecialtyId)!.Name,
                    pic = doctor.ProfilePic!,
                    number = doctor.phoneNumber,
                    day = time.day,
                    year = time.year,
                    month = time.month,
                    name = doctor.Name,
                    AppointmentTime = item.appointmentTime,
                    fee = doctor.fee,
                    unviersity = doctor.universiry,
                    rated=item.rated
                };
                UserAppointments.Add(UserAppointment);
            }


            return UserAppointments;
        }
    

        public List<AppointmenstDTO> GetDoctorAppointments(int DoctorId, bool state)
        {
            List<Appointments> appointmentsForDocto = _context.appointments.OrderByDescending(b => b.Id).Where(a => a.doctorid == DoctorId && a.Done == state &&a.Canceled==false).ToList() ?? [];
            List<AppointmenstDTO> DoctorAppointments = [];
            foreach (var item in appointmentsForDocto)
            {
                User user = _context.users.Find(item.userid)!;
                Times time = _context.times.Find(item.timeid)!;
                AppointmenstDTO DoctorAppointment = new AppointmenstDTO()
                {
                    id = item.Id,
                    doctorid = DoctorId,
                    timeid = item.timeid,
                    userid = item.userid,
                    pic = user.ProfilePic!,
                    number = user.phoneNumber,
                    day = time.day,
                    year = time.year,
                    month = time.month,
                    name = user.Name,
                    AppointmentTime = item.appointmentTime,
                    rated = item.rated

                };
                DoctorAppointments.Add(DoctorAppointment);
            }


            return DoctorAppointments;
        }
    }
}


