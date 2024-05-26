using AA_Task.Models;

namespace AA_Task.Interface
{
    public interface IDoctorRepo
    {
        bool AddDoctor(Doctor doctor);
        int login(string email , string password);
        Doctor GetDoctorById(int id);
        List<User> getPateintsForDoctor(int doctorId);
        List<Doctor> GetDoctorsBySPeciality(string specialty);
        List<Doctor> GetDoctorsByName(string name, string specialty);


    }
}
