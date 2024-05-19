using AA_Task.DataContext;
using AA_Task.Interface;
using AA_Task.Models;

namespace AA_Task.Repository
{
    public class BodyPartRepo : IBodypartRepository
    {
        private readonly TaskDataContext _context;
        public BodyPartRepo(TaskDataContext context)
        {
            _context = context;
        }
        public bool addBodypart(string bodypart)
        {
            BodyPart bP=_context.bodyParts.Where(b=>b.bodypartInEnglis==bodypart.ToLower()).FirstOrDefault();
            if(bP!=null)
            {
                return false;
            }
            else
            {
               BodyPart bodyPartToBeadded= new BodyPart()
               {
                   bodypartInEnglis = bodypart.ToLower(),
               };
                _context.bodyParts.Add(bodyPartToBeadded);
                return _context.SaveChanges()>0?true:false;
            }
        }

        public List<BodyPart> GetBodyPart()
        {
            List<BodyPart> listOfBodypart=new List<BodyPart>();
            listOfBodypart = _context.bodyParts.ToList();
            return listOfBodypart;
        }
    }
}
