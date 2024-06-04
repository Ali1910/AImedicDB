using AA_Task.Models;

namespace AA_Task.Interface
{
    public interface IBMI
    {
        bool addBMIValue(BMI bmi);
        float getBMILastValue(int userId);
        List<BMI> getBMIReadsForUser(int userId);
        bool DeleteBMIRead(int BMIId);
    }
}
