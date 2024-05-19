using AA_Task.Models;

namespace AA_Task.Interface
{
    public interface IBodypartRepository
    {
        bool addBodypart(string bodypart);
        List<BodyPart> GetBodyPart();
    }
}
