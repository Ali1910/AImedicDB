using AA_Task.DTO;
using AA_Task.Models;

namespace AA_Task.Interface
{
    public interface IUserRepo
    {
        bool AddUser(User user);
        int login(string email , string password);
        User GetProfileDetials(int id);
    }
}
