using AA_Task.DataContext;
using AA_Task.Interface;
using AA_Task.Models;

namespace AA_Task.Repository
{
    public class BMIRepo : IBMI
    {
        private readonly TaskDataContext _context;
        public BMIRepo(TaskDataContext context)
        {

            _context = context;

        }
        public bool addBMIValue(BMI bmi)
        {
            _context.BMI.Add(bmi);
           return _context.SaveChanges() > 0 ? true : false;
        }

        public float getBMILastValue(int userId)
        {
            BMI bmi = _context.BMI.OrderByDescending(b => b.id).Where(b => b.userid == userId).FirstOrDefault();

            return bmi == null ? 0 : bmi.value;
        }
    }
}
