﻿using AA_Task.DataContext;
using AA_Task.Interface;
using AA_Task.Models;
using BookingPage.Models;
using System.Collections.Generic;
using System.Xml.Linq;

namespace AA_Task.Repository
{
    public class DoctorRepo : IDoctorRepo
    {
        private readonly TaskDataContext _Context;
        public DoctorRepo(TaskDataContext context)
        {
            _Context = context;
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
            if(doctor != null)
            {
                return doctor;
            }
            else
            {
                return null;
            }
        }

        public List<Doctor> GetDoctorsByName(string name)
        {
           var ListOfDoctor=_Context.doctors.Where(d=>d.Name==name).ToList();
            return ListOfDoctor;
        }

        public List<Doctor> GetDoctorsBySPeciality(string specialty)
            
        {
            var specialtyId=_Context.specialties.Where(s=>s.Name==specialty).FirstOrDefault().Id;
            var ListOfDoctor = _Context.doctors.Where(d => d.doctorspecialtyId == specialtyId).ToList();
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
    }
}
