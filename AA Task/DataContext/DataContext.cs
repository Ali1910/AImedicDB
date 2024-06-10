




using AA_Task.Models;
using BookingPage.Models;
using Microsoft.EntityFrameworkCore;

namespace AA_Task.DataContext
{
    public class TaskDataContext : DbContext
    {
        public TaskDataContext(DbContextOptions options):base(options) 
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Doctor>().Property(p=>p.Rating).HasDefaultValue(0);
            modelBuilder.Entity<User>().Property(p => p.NFCId).HasDefaultValue(null);
            modelBuilder.Entity<BMI>().HasOne<User>().WithMany().HasForeignKey(b => b.userid);
            modelBuilder.Entity<diagnosis>().HasOne<Doctor>().WithMany().HasForeignKey(r => r.doctorId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<diagnosis>().HasOne<User>().WithMany().HasForeignKey(r => r.UserId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<diagnosis>().HasOne<Appointments>().WithMany().HasForeignKey(r => r.ApponitmentId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<RatingAndComments>().HasOne<Doctor>().WithMany().HasForeignKey(r => r.DoctorId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<RatingAndComments>().HasOne<User>().WithMany().HasForeignKey(r => r.UserId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<RatingAndComments>().HasOne<Appointments>().WithMany().HasForeignKey(r => r.ApponintmetId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<RatingAndComments>().Property(r => r.commment).HasDefaultValue(null);
            modelBuilder.Entity<Question>().Property(p=>p.Answered).HasDefaultValue(false);
            modelBuilder.Entity<Symptom>().HasOne<BodyPart>().WithMany().HasForeignKey(b => b.boypartId);
            modelBuilder.Entity<HealthAdvice>().HasOne<Doctor>().WithMany().HasForeignKey(H => H.doctorId);
            modelBuilder.Entity<Question>().HasOne<User>().WithMany().HasForeignKey(q => q.User);
            modelBuilder.Entity<answer>().HasOne<Doctor>().WithMany().HasForeignKey(a => a.doctor);
            modelBuilder.Entity<answer>().HasOne<Question>().WithMany().HasForeignKey(a => a.question);
            modelBuilder.Entity<DoctorTimes>().Property(b=>b.empty).HasDefaultValue(true);
            modelBuilder.Entity<Appointments>().Property(b => b.Canceled).HasDefaultValue(false);
            modelBuilder.Entity<Appointments>().Property(b => b.Done).HasDefaultValue(false);
            modelBuilder.Entity<Appointments>().Property(b => b.rated).HasDefaultValue(false);
            modelBuilder.Entity<User>().Property(u=>u.gender).HasMaxLength(4);
            modelBuilder.Entity<User>().Property(u => u.phoneNumber).HasMaxLength(11);
            modelBuilder.Entity<User>().Property(u => u.City).HasMaxLength(15);
            modelBuilder.Entity<User>().Property(u => u.Name).HasMaxLength(30);
            modelBuilder.Entity<DoctorTimes>().HasOne<Doctor>().WithMany().HasForeignKey(b => b.DoctorId);
            modelBuilder.Entity<DoctorTimes>().HasOne<Times>().WithMany().HasForeignKey(b => b.TimeId);
            modelBuilder.Entity<UserTimes>().HasOne<User>().WithMany().HasForeignKey(b => b.userKey);
            modelBuilder.Entity<UserTimes>().HasOne<Times>().WithMany().HasForeignKey(b => b.Timekey);
            modelBuilder.Entity<Appointments>().HasOne<User>().WithMany().HasForeignKey(b => b.userid);
            modelBuilder.Entity<Appointments>().HasOne<Doctor>().WithMany().HasForeignKey(b => b.doctorid);
            modelBuilder.Entity<Appointments>().HasOne<Times>().WithMany().HasForeignKey(b => b.timeid);
            modelBuilder.Entity<Doctor>().HasOne<Specialty>().WithMany().HasForeignKey(b => b.doctorspecialtyId);
            modelBuilder.Entity<BMI>().Property(u => u.year).HasMaxLength(4);
            modelBuilder.Entity<BMI>().Property(u => u.month).HasMaxLength(2);
            modelBuilder.Entity<BMI>().Property(u => u.day).HasMaxLength(2);
            modelBuilder.Entity<BMI>().Property(u => u.hour).HasMaxLength(2);
            modelBuilder.Entity<BMI>().Property(u => u.minute).HasMaxLength(2);
        }
        public DbSet<User> users { get; set; }
        public DbSet<Specialty> specialties { get; set; }
        public DbSet<Doctor> doctors { get; set; }
        public DbSet<Medication> medications { get; set; }
        public DbSet<Warning> warnings { get; set; }
        public DbSet<MedicationWarningJoin> medicationWarningJoins { get; set; }
        public DbSet<Question> questions { get; set; }
        public DbSet<answer> answers { get; set; }
        public DbSet<Times> times { get; set; }
        public DbSet<UserTimes> userTimes { get; set; }
        public DbSet<DoctorTimes> doctorTimes { get; set; }
        public DbSet<Appointments> appointments { get; set; }
        public DbSet<HealthAdvice> healthAdvices { get; set; }
        public DbSet<Symptom> symptoms { get; set; }
        public DbSet<BodyPart> bodyParts { get; set; }
        public DbSet<RatingAndComments> ratingAndComments { get; set; }
        public DbSet<diagnosis> diagnosesSummary { get; set; }
        public DbSet<BMI> BMI { get; set; }
    }
}
