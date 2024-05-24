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
            User user = _context.users.Where(u=>u.Email==email&&u.Password==password).FirstOrDefault();
            if(user == null)
            {
                return 0;
            }
            else
            {
                if(email!=user.Email||password!=user.Password)
                {
                    return 0;
                }
                return user.Id;
            }
            
        }

        public string updateCity(int id, string newcity)
        {
            User user = _context.users.Find(id)!;
            user.City = newcity;
            return _context.SaveChanges()>0?"تم تعديل المدينة بنجاح":"حدث خطأ اثناءالتعديل حاول مرة اخرى";
        }

        public string updatepassword(int id, string oldpassword, string newpassword)
        {
            User user = _context.users.Find(id)!;
            if (user.Password!=oldpassword)
            {
                return "برجاء إدخال كلمة مرور القديمة بشكل صحيح";
            }
            else
            {
                if(oldpassword==newpassword) 
                {
                    return "برجاء إدخال كلمة سر مختلفة عن كلمة السر القديمة";
                }
                user.Password = newpassword;
                return _context.SaveChanges()>0?"تم تعديل كلمة المرور بنجاح":"حاول مرة اخرى";
            }
        }

        public string updatePhoneNumber(int id, string newPhoneNumbder)
        {
            User user = _context.users.Find(id)!;
            
            if(newPhoneNumbder==user.phoneNumber)
            {
                return "لقد قمت بأدخال نفس رقم الهاتف السابق";
            }
            user.phoneNumber = newPhoneNumbder;
            return _context.SaveChanges() > 0 ? "تم تعديل رقم الهاتف بنجاح" : "حدث خطأ اثناءالتعديل حاول مرة اخرى";
        }
    }
}
