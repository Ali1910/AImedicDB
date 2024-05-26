using AA_Task.DataContext;
using AA_Task.Interface;
using BookingPage.Models;

namespace AA_Task.Repository
{
    public class TimesRepo : ITimesRepo
    {
        private readonly TaskDataContext _context;
        public TimesRepo(TaskDataContext context)
        {
            _context = context;
        }
        public bool addTime(string YearValue, string MonthValue, string DayValue)
        {
            
            Times time= new Times()
            {
                month=MonthValue, day=DayValue, year=YearValue
            };
            _context.Add(time);
            if (_context.SaveChanges()>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Times> GetTimes()
        {
            return _context.times.ToList();
        }
    }
}
