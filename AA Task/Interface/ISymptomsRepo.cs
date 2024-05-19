using AA_Task.Models;

namespace AA_Task.Interface
{
    public interface ISymptomsRepo
    {
        bool addsymptom(string symptominEnglish, string syptomInArabic,string bodypartName);
        List<Symptom> getSymptoms(int bodypartId);
    }
}
