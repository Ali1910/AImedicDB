using AA_Task.Models;

namespace AA_Task.Interface
{
    public interface IdiagnosisSummary
    {
        bool addDiagnoses(diagnosis diagnosis);
        List<diagnosis> GetDiagnosesForUser(int userId);
        Dictionary<string,dynamic> GetDiagnosesForDoctor(int doctorId);
        bool deleteDiagnosis(int diagnosisId);
    }
}
