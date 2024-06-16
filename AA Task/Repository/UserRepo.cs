using AA_Task.DataContext;
using AA_Task.DTO;
using AA_Task.Interface;
using AA_Task.Models;
using howtohandelimages.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AA_Task.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly TaskDataContext _context;
        private readonly iFileService _service;
        public UserRepo(TaskDataContext context,iFileService service)
        {
            _context = context;
            _service = service;
        }

        public Tuple<bool, string> addNFCId(string NFCId, int id)

        {

            User user = _context.users.Find(id)!;
            if (user.NFCId == null)
            {
                User userNFC = _context.users.Where(u => u.NFCId == NFCId).FirstOrDefault();
                if (userNFC == null)
                {
                    user.NFCId = NFCId;
                    return _context.SaveChanges() > 0 ? new Tuple<bool, string>(true, "تم تسجيل الكارت الذكي الخاص بك بنجاح") : new Tuple<bool, string>(true, "فشل تسجيل الكارت الذكي الخاص بك حاول مرة أخرى");

                }
                else
                {
                    return new Tuple<bool, string>(true, "هذا الكارت موجود مسبقا ");
                }
            }

            else
            {
                return new Tuple<bool, string>(true, "أنت تملك كارت ذكي بالفعل ");
            }
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

        public int loginUsingNfc(string NFC)
        {
            User user=_context.users.Where(u=>u.NFCId==NFC).FirstOrDefault();
            if(user == null)
            {
                return 0;

            }
            else
            {
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

        public bool updateUserProfilePic(IFormFile image, int userid)
        {
            
                User user = _context.users.Find(userid);
                var result = _service.SaveImage(image);
                if (result.Item1 == 1)
                {
                    user.ProfilePic = result.Item2;
                }
                return _context.SaveChanges() > 0 ? true : false;
            
        }
    }
}
