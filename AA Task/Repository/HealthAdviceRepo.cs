using AA_Task.DataContext;
using AA_Task.Interface;
using AA_Task.Models;

namespace AA_Task.Repository
{
    public class HealthAdviceRepo : IHealthAdviceRepo
    {
        private readonly TaskDataContext _context;
        public HealthAdviceRepo(TaskDataContext context)
        {
             _context= context ; 
        }

        public bool deleteHealthAdvice(int healthAdviceId)
        {
            HealthAdvice healthAdvice = _context.healthAdvices.Find(healthAdviceId);
            _context.healthAdvices.Remove(healthAdvice);
            return _context.SaveChanges()>0?true:false;
        }

        public Dictionary<string, dynamic> GetAllHealthAvices(int pagenum, int pagesize)
        {
            List<HealthAdvice> healthAdvices = _context.healthAdvices.OrderByDescending(h=>h.id).Skip((pagenum-1)*pagesize).Take(pagesize).ToList();
            List<Doctor>doctors=new List<Doctor>();
            List<Specialty> specialties = new List<Specialty>();
            foreach (var item in healthAdvices)
            {
                Doctor doctor = _context.doctors.Find(item.doctorId);
                Specialty specialty = _context.specialties.Find(doctor.doctorspecialtyId);
                doctors.Add(doctor);
                specialties.Add(specialty);
            }
            Dictionary<string, dynamic> response= new Dictionary<string, dynamic>();
            response.Add("healthAdvice", healthAdvices);
            response.Add("doctor", doctors);
            response.Add("spec", specialties);
            return response;
        }

        public bool postHealthAdvice(int doctorId, string content)
        {
            HealthAdvice healthadvice=new HealthAdvice() 
            {
                doctorId = doctorId,
                Content = content
            };
            
            _context.healthAdvices.Add(healthadvice);
            return _context.SaveChanges()>0?true:false;
        }

        public bool UpdateHealthAdvice(int healthAdviceId, string content)
        {
            HealthAdvice healthadvice = _context.healthAdvices.Find(healthAdviceId);
            healthadvice.Content=content;
            _context.healthAdvices.Update(healthadvice);
            return _context.SaveChanges()>0?true:false;

        }
    }
}
