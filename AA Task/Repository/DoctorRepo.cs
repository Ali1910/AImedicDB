using AA_Task.DataContext;
using AA_Task.Interface;
using AA_Task.Models;
using System.Xml.Linq;

namespace AA_Task.Repository
{
    public class DoctorRepo:IDoctorRepo
    {
        private readonly TaskDataContext _Context;
        public DoctorRepo(TaskDataContext context)
        {
            _Context = context;
        }

        public bool AddDoctor(Doctor doctor)
        {
           Doctor checker= _Context.doctors.Where(d => d.Email == doctor.Email).FirstOrDefault();
            if (checker != null)
            {
                return false;
            }
            else
            {
                _Context.doctors.Add(doctor);
                return _Context.SaveChanges() > 0 ? true : false;
            }

           
        }

        public List<Doctor> GetDoctorsByName(string name)
        {
           var ListOfDoctor=_Context.doctors.Where(d=>d.Name==name).ToList();
            return ListOfDoctor;
        }

        public List<Doctor> GetDoctorsBySPeciality(string specialty)
            
        {
            var specialtyId=_Context.specialties.Where(s=>s.Name==specialty).FirstOrDefault().Id;
            var ListOfDoctor = _Context.doctors.Where(d => d.doctorspecialtyId == specialtyId).ToList();
            return ListOfDoctor;
        }

        public int login(string email, string password)
        {
            Doctor doctor=_Context.doctors.Where(d=>d.Email==email&&d.Password==password).FirstOrDefault();

            return doctor is null ? 0 : doctor.Id;
        }
    }
}
