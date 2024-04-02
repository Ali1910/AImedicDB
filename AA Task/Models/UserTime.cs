using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingPage.Models
{
    public class UserTimes    {
        public int Id { get; set; }
        public int userKey { get; set; }
        public int Timekey { get; set; }
        public bool empty { get; set; }
        public string Time { get; set; }



    }
}
