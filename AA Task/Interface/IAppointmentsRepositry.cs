using AA_Task.DTO;
using AA_Task.Models;
using BookingPage.Models;
namespace school
{
    public interface IAppointmentRepository
    {
        // for post request
        bool addAppointment(string appointmentime, int timeid, int UserId, int doctorId);
         //for update requset

        bool UpdateAppointment(string year, string day, string month, int AppointmentId, string appointmentime);
        //// getting doctor times for a date 
        List<DoctorTimes> getDoctorTimesforDate(int doctorId, string year, string month, string day);

        List<AppointmenstDTO> GetUserAppointments(int userId, bool state);
        //for delete request
        bool deleteAppointment(int AppointmentId);
      

    }
}
