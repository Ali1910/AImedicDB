using AA_Task.Models;

namespace AA_Task.Interface
{
    public interface IHealthAdviceRepo
    {
        Dictionary<string,dynamic> GetAllHealthAvices(int pagenum,int pagesize);
        bool postHealthAdvice(int doctorId,string content);
        bool deleteHealthAdvice(int healthAdviceId);
        bool UpdateHealthAdvice(int healthAdviceId, string content);


    }
}
