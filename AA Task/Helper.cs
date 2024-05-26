using AA_Task.DTO;
using AA_Task.Models;
using AutoMapper;

namespace AA_Task
{
    public class Helper : Profile
    {
        public Helper()
        {
        
            CreateMap<Specialty, SpecialtyDTO>();
            CreateMap<SpecialtyDTO, Specialty>();
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<Question, QuestionDTO>();
            CreateMap<QuestionDTO, Question>();
        }
    }
}
