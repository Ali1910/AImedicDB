﻿// <auto-generated />
using AA_Task.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AA_Task.Migrations
{
    [DbContext(typeof(TaskDataContext))]
    [Migration("20240524184643_update3")]
    partial class update3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AA_Task.Models.answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("doctor")
                        .HasColumnType("int");

                    b.Property<int>("question")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("doctor");

                    b.HasIndex("question");

                    b.ToTable("answers");
                });

            modelBuilder.Entity("AA_Task.Models.BMI", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("userid")
                        .HasColumnType("int");

                    b.Property<float>("value")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.HasIndex("userid");

                    b.ToTable("BMI");
                });

            modelBuilder.Entity("AA_Task.Models.BodyPart", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("bodypartInArabic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bodypartInEnglis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("bodyParts");
                });

            modelBuilder.Entity("AA_Task.Models.diagnosis", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("doctorId")
                        .HasColumnType("int");

                    b.Property<string>("summaryOfTheSession")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("doctorId");

                    b.HasIndex("userid");

                    b.ToTable("diagnosesSummary");
                });

            modelBuilder.Entity("AA_Task.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BirthDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Rating")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("real")
                        .HasDefaultValue(0f);

                    b.Property<int>("doctorspecialtyId")
                        .HasColumnType("int");

                    b.Property<int>("fee")
                        .HasColumnType("int");

                    b.Property<string>("location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("universiry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("doctorspecialtyId");

                    b.ToTable("doctors");
                });

            modelBuilder.Entity("AA_Task.Models.HealthAdvice", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("doctorId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("doctorId");

                    b.ToTable("healthAdvices");
                });

            modelBuilder.Entity("AA_Task.Models.Medication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("EnglishName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("about")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("usedfor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("medications");
                });

            modelBuilder.Entity("AA_Task.Models.MedicationWarningJoin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MedicationId")
                        .HasColumnType("int");

                    b.Property<int>("WarningId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MedicationId");

                    b.HasIndex("WarningId");

                    b.ToTable("medicationWarningJoins");
                });

            modelBuilder.Entity("AA_Task.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Answered")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("User")
                        .HasColumnType("int");

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("User");

                    b.ToTable("questions");
                });

            modelBuilder.Entity("AA_Task.Models.RatingAndComments", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("appointmentId")
                        .HasColumnType("int");

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("doctorId")
                        .HasColumnType("int");

                    b.Property<float>("rating")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.HasIndex("UserId");

                    b.HasIndex("appointmentId");

                    b.HasIndex("doctorId");

                    b.ToTable("ratingAndComments");
                });

            modelBuilder.Entity("AA_Task.Models.Specialty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("specialties");
                });

            modelBuilder.Entity("AA_Task.Models.Symptom", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("boypartId")
                        .HasColumnType("int");

                    b.Property<string>("symptomInArabic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("symptomInEnglish")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("boypartId");

                    b.ToTable("symptoms");
                });

            modelBuilder.Entity("AA_Task.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BirthDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecialCondition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("AA_Task.Models.Warning", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("WarningName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("warnings");
                });

            modelBuilder.Entity("BookingPage.Models.Appointments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Canceled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("Done")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("appointmentTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("doctorid")
                        .HasColumnType("int");

                    b.Property<int>("timeid")
                        .HasColumnType("int");

                    b.Property<int>("userid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("doctorid");

                    b.HasIndex("timeid");

                    b.HasIndex("userid");

                    b.ToTable("appointments");
                });

            modelBuilder.Entity("BookingPage.Models.DoctorTimes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("TimeId")
                        .HasColumnType("int");

                    b.Property<string>("datetime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("empty")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("TimeId");

                    b.ToTable("doctorTimes");
                });

            modelBuilder.Entity("BookingPage.Models.Times", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("day")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("month")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("year")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("times");
                });

            modelBuilder.Entity("BookingPage.Models.UserTimes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Timekey")
                        .HasColumnType("int");

                    b.Property<bool>("empty")
                        .HasColumnType("bit");

                    b.Property<int>("userKey")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Timekey");

                    b.HasIndex("userKey");

                    b.ToTable("userTimes");
                });

            modelBuilder.Entity("AA_Task.Models.answer", b =>
                {
                    b.HasOne("AA_Task.Models.Doctor", null)
                        .WithMany()
                        .HasForeignKey("doctor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AA_Task.Models.Question", null)
                        .WithMany()
                        .HasForeignKey("question")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AA_Task.Models.BMI", b =>
                {
                    b.HasOne("AA_Task.Models.User", null)
                        .WithMany()
                        .HasForeignKey("userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AA_Task.Models.diagnosis", b =>
                {
                    b.HasOne("AA_Task.Models.Doctor", null)
                        .WithMany()
                        .HasForeignKey("doctorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AA_Task.Models.User", null)
                        .WithMany()
                        .HasForeignKey("userid")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("AA_Task.Models.Doctor", b =>
                {
                    b.HasOne("AA_Task.Models.Specialty", null)
                        .WithMany()
                        .HasForeignKey("doctorspecialtyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AA_Task.Models.HealthAdvice", b =>
                {
                    b.HasOne("AA_Task.Models.Doctor", null)
                        .WithMany()
                        .HasForeignKey("doctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AA_Task.Models.MedicationWarningJoin", b =>
                {
                    b.HasOne("AA_Task.Models.Medication", "medication")
                        .WithMany("medicationWarningJoins")
                        .HasForeignKey("MedicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AA_Task.Models.Warning", "warning")
                        .WithMany("medicationWarningJoins")
                        .HasForeignKey("WarningId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("medication");

                    b.Navigation("warning");
                });

            modelBuilder.Entity("AA_Task.Models.Question", b =>
                {
                    b.HasOne("AA_Task.Models.User", null)
                        .WithMany()
                        .HasForeignKey("User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AA_Task.Models.RatingAndComments", b =>
                {
                    b.HasOne("AA_Task.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BookingPage.Models.Appointments", null)
                        .WithMany()
                        .HasForeignKey("appointmentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AA_Task.Models.Doctor", null)
                        .WithMany()
                        .HasForeignKey("doctorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("AA_Task.Models.Symptom", b =>
                {
                    b.HasOne("AA_Task.Models.BodyPart", null)
                        .WithMany()
                        .HasForeignKey("boypartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookingPage.Models.Appointments", b =>
                {
                    b.HasOne("AA_Task.Models.Doctor", null)
                        .WithMany()
                        .HasForeignKey("doctorid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookingPage.Models.Times", null)
                        .WithMany()
                        .HasForeignKey("timeid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AA_Task.Models.User", null)
                        .WithMany()
                        .HasForeignKey("userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookingPage.Models.DoctorTimes", b =>
                {
                    b.HasOne("AA_Task.Models.Doctor", null)
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookingPage.Models.Times", null)
                        .WithMany()
                        .HasForeignKey("TimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookingPage.Models.UserTimes", b =>
                {
                    b.HasOne("BookingPage.Models.Times", null)
                        .WithMany()
                        .HasForeignKey("Timekey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AA_Task.Models.User", null)
                        .WithMany()
                        .HasForeignKey("userKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AA_Task.Models.Medication", b =>
                {
                    b.Navigation("medicationWarningJoins");
                });

            modelBuilder.Entity("AA_Task.Models.Warning", b =>
                {
                    b.Navigation("medicationWarningJoins");
                });
#pragma warning restore 612, 618
        }
    }
}
