using AA_Task.DTO;
using AA_Task.Models;

namespace AA_Task.Interface
{
    public interface IQuestionRepo
    {
        bool addquestion(Question question);
        bool deletequestion(int questionId);
        Dictionary<string, dynamic> getAllquestions(int pagesize,int pagenum);
        Dictionary<string, dynamic> getMyQuestions(int userID, int pagesize, int pagenum);
    }
}
