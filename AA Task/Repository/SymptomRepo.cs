using AA_Task.DataContext;
using AA_Task.Interface;
using AA_Task.Models;

namespace AA_Task.Repository
{
    public class SymptomRepo : ISymptomsRepo
    {
        private readonly TaskDataContext _context;
        public SymptomRepo(TaskDataContext context)
        {
            _context = context;
        }
        public bool addsymptom(string symptominEnglish, string syptomInArabic)
        {
            
            
            Symptom symptom = _context.symptoms.Where(s=>s.symptomInEnglish== symptominEnglish.ToLower()).FirstOrDefault();
            if (symptom!=null)
            {
                return false;
            }
            else
            {
                Symptom symptomToBeAdded=new Symptom() { 
                    symptomInArabic=syptomInArabic,
                    symptomInEnglish= symptominEnglish.ToLower(),
                    
                };
                _context.symptoms.Add(symptomToBeAdded);
                return _context.SaveChanges()>0?true:false;
            }
        }

        public List<Symptom> getSymptoms()
        {
            List<Symptom> listOfSymptoms=_context.symptoms.ToList();
            return listOfSymptoms;

        }
    }
}
