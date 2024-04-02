using AA_Task.DataContext;
using AA_Task.DTO;
using AA_Task.Interface;
using AA_Task.Models;

namespace AA_Task.Repository
{
    public class QuestionRepo : IQuestionRepo
    {
        private readonly TaskDataContext _context;
        public QuestionRepo(TaskDataContext context)
        {
            _context = context;
        }
        public bool addquestion(Question question)
        {
            _context.questions.Add(question);
            return _context.SaveChanges()>0?true:false;
        }

        public List<Question> getAllquestions(int pagesize, int pagenum)
        {
            return _context.questions.Skip((pagenum-1)*pagesize).Take(pagesize).ToList();
        }

        public List<Question> getMyQuestions(int userID, int pagesize, int pagenum)
        {
            return _context.questions.Where(q=>q.User==userID).Skip((pagenum - 1) * pagesize).Take(pagesize).ToList();
        }
    }
}
