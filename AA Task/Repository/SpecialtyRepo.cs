using AA_Task.DataContext;
using AA_Task.Interface;
using AA_Task.Models;

namespace AA_Task.Repository
{
    public class SpecialtyRepo : IspecialtyRepo
    {
        private readonly TaskDataContext _Context;
        public SpecialtyRepo(TaskDataContext Context)
        {
            _Context = Context;
        }
        public bool AddSpecialty(Specialty specialty)
        {
            _Context.specialties.Add(specialty);
            return _Context.SaveChanges()>0?true:false;
        }

        public List<Specialty> GetSpecialties()
        {
            return _Context.specialties.ToList();
        }

        public Specialty GetSpecialtyByName(string name)
        {
          var specialty=_Context.specialties.Where(x => x.Name == name).FirstOrDefault();
            
            
            return specialty;
        }
        
    }
}
