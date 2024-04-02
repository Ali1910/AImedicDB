using AA_Task.DTO;
using AA_Task.Models;
using AutoMapper;

namespace AA_Task
{
    public class Helper : Profile
    {
        public Helper()
        {
            CreateMap<Doctor, DoctorDTO>();
            CreateMap<DoctorDTO, Doctor>();
            CreateMap<Specialty, SpecialtyDTO>();
            CreateMap<SpecialtyDTO, Doctor>();
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<Question, QuestionDTO>();
            CreateMap<QuestionDTO, Question>();
        }
    }
}
