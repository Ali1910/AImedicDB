using AA_Task.DataContext;
using AA_Task.Interface;
using AA_Task.Models;
using BookingPage.Models;

namespace AA_Task.Repository
{
    public class RatingAndCommentRepo : IratingAndCommentRepo
    {
        private readonly TaskDataContext _context;
        public RatingAndCommentRepo(TaskDataContext context)
        {
            _context = context;
            
        }
        public bool addrating(int doctorid, int appointmnetId, int userId, string rating, string? comment)
        {
            RatingAndComments RatingAndComment=new RatingAndComments()
            {
                DoctorId= doctorid,
                ApponintmetId =appointmnetId,
                UserId  =userId,
                Rating =rating,
                commment=comment
            };
           
            _context.ratingAndComments.Add(RatingAndComment);
            Appointments app = _context.appointments.Find(appointmnetId);
            app.rated = true;
            _context.appointments.Update(app);
            return _context.SaveChanges()>0?true:false;
        }
    }
}
