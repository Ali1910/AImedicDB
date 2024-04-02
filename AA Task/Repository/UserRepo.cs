using AA_Task.DataContext;
using AA_Task.DTO;
using AA_Task.Interface;
using AA_Task.Models;
using System.Linq;

namespace AA_Task.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly TaskDataContext _context;
        public UserRepo(TaskDataContext context)
        {
            _context = context;
        }
        public bool AddUser(User user)
        {
            var userEixst=_context.users.Any(u=>u.Email==user.Email); 
            if (userEixst) 
            { 
                return false;
            }else
            {
                _context.users.Add(user);
                return _context.SaveChanges()>0?true:false; 
            }
        }

        public User GetProfileDetials(int id)
        {
            return _context.users.Find(id);
        }

        public int login(string email , string password)
        {
            var user = _context.users.Where(u => u.Email == email && u.Password == password).Select(u => new  { u.Id }).FirstOrDefault();
            return user is null?0:user.Id;
        }
    }
}
