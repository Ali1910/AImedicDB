using BookingPage.Models;

namespace AA_Task.Interface
{
    public interface ITimesRepo
    {
        bool addTime(string YearValue,string MonthValue , string DayValue);
        List<Times> GetTimes();
        Times getTimeById(int id);
        bool deleteTime(int id);
        
    }
}
