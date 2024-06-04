using BookingPage.Models;

namespace AA_Task.Interface
{
    public interface IdoctorTimes
    {
        bool addDoctortimes(DoctorTimes doctorTimes);
        bool deleteDoctorTime(int DoctorTimeId);
        bool deleteTimesForDoctor(int doctorId);
    }
}
