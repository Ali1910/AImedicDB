﻿using AA_Task.DataContext;
using AA_Task.Interface;
using AA_Task.Models;
using BookingPage.Models;
using howtohandelimages.Repository.Abstract;
using System.Collections.Generic;
using System.Numerics;
using System.Xml.Linq;

namespace AA_Task.Repository
{
    public class DoctorRepo : IDoctorRepo
    {
        private readonly TaskDataContext _Context;
        private readonly iFileService _service;
        public DoctorRepo(TaskDataContext context,iFileService service)
        {
            _Context = context;
            _service = service;
        }

        public bool AddDoctor(Doctor doctor)
        {
           Doctor checker= _Context.doctors.Where(d => d.Email == doctor.Email).FirstOrDefault();
            if (checker != null)
            {
                return false;
            }
            else
            {
                _Context.doctors.Add(doctor);
                return _Context.SaveChanges() > 0 ? true : false;
            }

           
        }

        public Doctor GetDoctorById(int id)
        {
            Doctor doctor = _Context.doctors.Find(id)!;
            List<RatingAndComments> ratings=_Context.ratingAndComments.Where(d => d.DoctorId == id).ToList();
            double ratingSum = 0;
            foreach (RatingAndComments rating in ratings)
            {
                ratingSum = ratingSum + double.Parse(rating.Rating);
                
            }
            if (ratings.Count == 0)
            {
                doctor.Rating = ratingSum / 1;
            }else
            doctor.Rating= ratingSum/ratings.Count;
            if(doctor != null)
            {
                return doctor;
            }
            else
            {
                return null;
            }
        }

        public List<Doctor> GetDoctorsByName(string name,string spec)
        {
            Specialty specility = _Context.specialties.Where(s => s.Name == spec).FirstOrDefault();
           var ListOfDoctor=_Context.doctors.Where(d=>d.Name.Contains(name)&&d.doctorspecialtyId==specility.Id).ToList();
            foreach (var item in ListOfDoctor)
            {
                List<RatingAndComments> ratings = _Context.ratingAndComments.Where(d => d.DoctorId == item.Id).ToList();
                double ratingSum = 0;
                foreach (RatingAndComments rating in ratings)
                {
                    ratingSum = ratingSum + double.Parse(rating.Rating);

                }
                if (ratings.Count == 0)
                {
                    item.Rating = ratingSum / 1;
                }
                else
                    item.Rating = ratingSum / ratings.Count;

            }
            return ListOfDoctor;
        }

        public List<Doctor> GetDoctorsBySPeciality(string specialty)
            
        {
            var specialtyId=_Context.specialties.Where(s=>s.Name==specialty).FirstOrDefault().Id;
            var ListOfDoctor = _Context.doctors.Where(d => d.doctorspecialtyId == specialtyId).ToList();
            foreach (var item in ListOfDoctor)
            {
                List<RatingAndComments> ratings = _Context.ratingAndComments.Where(d => d.DoctorId == item.Id).ToList();
                double ratingSum = 0;
                foreach (RatingAndComments rating in ratings)
                {
                    ratingSum = ratingSum + double.Parse(rating.Rating);

                }
                if (ratings.Count == 0)
                {
                    item.Rating = ratingSum / 1;
                }
                else
                    item.Rating = ratingSum / ratings.Count;

            }
            return ListOfDoctor;
        }

        public List<User> getPateintsForDoctor(int doctorId)
        {
            List< Appointments> appointments= _Context.appointments.Where(p=>p.doctorid==doctorId&&p.Canceled==false).ToList();
            List<User> users = new List<User>();
            foreach(var appointment in appointments)
            {
                User user = _Context.users.Find(appointment.userid)!;
                users.Add(user);
            }

            return users;
        }

        public int login(string email, string password)
        {
            Doctor doctor=_Context.doctors.Where(d=>d.Email==email&&d.Password==password).FirstOrDefault();

            return doctor is null ? 0 : doctor.Id;
        }

        public bool updateDoctorProfilePic(IFormFile image,int DoctorId)
        {
            Doctor doctor = _Context.doctors.Find(DoctorId);
            var result = _service.SaveImage(image);
            if (result.Item1 == 1)
            {
                doctor.ProfilePic = result.Item2;
            }
            return _Context.SaveChanges()>0?true:false;
        }
    }
}
