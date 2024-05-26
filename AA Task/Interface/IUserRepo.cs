using AA_Task.DTO;
using AA_Task.Models;

namespace AA_Task.Interface
{
    public interface IUserRepo
    {
        bool AddUser(User user);
        int login(string email , string password);
        int loginUsingNfc(string NFC);
        Tuple<bool,string> addNFCId(string NFCId,int id);
        User GetProfileDetials(int id);
        string updatepassword(int id , string oldpassword,string newpassword);
        string updateCity(int id,  string newcity);
        string updatePhoneNumber(int id, string newPhoneNumbder);
    }
}
