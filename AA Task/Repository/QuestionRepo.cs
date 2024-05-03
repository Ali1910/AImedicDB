using AA_Task.DataContext;
using AA_Task.DTO;
using AA_Task.Interface;
using AA_Task.Models;
using System.Collections.Generic;

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

        public Dictionary<string, dynamic> getAllquestions(int pagesize, int pagenum)
        {
            List<Question> listOfQuestions= _context.questions.OrderByDescending(p=>p.Id).Skip((pagenum-1)*pagesize).Take(pagesize).ToList();
            List<User> listOfUsers = [];
            foreach (Question question in listOfQuestions)
            {
                User user = _context.users.Find(question.User)!;
                listOfUsers.Add(user);
            }
            Dictionary<string,dynamic> questions= new Dictionary<string,dynamic>();
            questions.Add("question", listOfQuestions);
            questions.Add("user", listOfUsers);




            return questions;
        }

        public Dictionary<string, dynamic> getMyQuestions(int userID, int pagesize, int pagenum)
        {
            List<Question> listOfQuestions = _context.questions.OrderByDescending(p => p.Id).Where(p=>p.User==userID).Skip((pagenum - 1) * pagesize).Take(pagesize).ToList();
            List<User> listOfUsers = [];
            foreach (Question question in listOfQuestions)
            {
                User user = _context.users.Find(question.User)!;
                listOfUsers.Add(user);
            }
            Dictionary<string, dynamic> questions = new Dictionary<string, dynamic>();
            questions.Add("question", listOfQuestions);
            questions.Add("user", listOfUsers);




            return questions;
        }
    }
}
