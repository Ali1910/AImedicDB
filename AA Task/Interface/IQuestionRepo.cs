using AA_Task.DTO;
using AA_Task.Models;

namespace AA_Task.Interface
{
    public interface IQuestionRepo
    {
        bool addquestion(Question question);
        List<Question> getAllquestions(int pagesize,int pagenum);
        List<Question> getMyQuestions(int userID, int pagesize, int pagenum);
    }
}
