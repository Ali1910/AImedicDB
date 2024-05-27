using AA_Task.Models;

namespace AA_Task.Interface
{
    public interface IBMI
    {
        bool addBMIValue(BMI bmi);
        float getBMILastValue(int userId);
    }
}
