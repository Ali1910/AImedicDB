using AA_Task.DataContext;
using AA_Task.Interface;
using AA_Task.Models;

namespace AA_Task.Repository
{
    public class AnswerRepo : IAnswerRepo
    {
        private readonly TaskDataContext _context;
        public AnswerRepo(TaskDataContext context)
        {
            _context = context;
        }
        public Tuple<bool,string> answerQuestion(int doctorId, int questionId, string content)
        {
            Question question = _context.questions.Find(questionId)!;
            


            if (question.Answered)
            {
               
                return new Tuple<bool, string>(false, "لقد تم الأجابة على هذا السؤال من قبل");
            }
            else
            {
                answer answer = new answer()
                {
                    content = content,
                    doctor = doctorId,
                    question = questionId
                };
                _context.answers.Add(answer);
                if (_context.SaveChanges() > 0)
                {
                    question.Answered = true;
                    _context.SaveChanges();
                    return new Tuple<bool, string>(true, "تم أضافة أجابتك بنجاح");
                }
                else
                {
                    return new Tuple<bool, string>(false, "حاول مرة أخرى");
                }
            }
        }
    }
}
