using AA_Task.DTO;
using AA_Task.Interface;
using AA_Task.Models;
using AutoMapper;
using howtohandelimages.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AA_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepo _repo;
        private readonly iFileService _service;
        private readonly IMapper _mapper;

        public DoctorController(IDoctorRepo repo, iFileService service,IMapper mapper)
        {
            _repo = repo;
            _service = service;
            _mapper = mapper;
            
        }
        [HttpPost]
        public IActionResult CreateDoctor([FromQuery] DoctorDTO doctorMapper)
        {
            var doctor = _mapper.Map<Doctor>(doctorMapper);
            if (doctorMapper.Image != null) 
            { 
                var result=_service.SaveImage(doctorMapper.Image);
                if(result.Item1==1)
                {
                    doctor.ProfilePic= result.Item2;
                }
               
                var checker=_repo.AddDoctor(doctor);
                if (checker)
                {
                    return Ok($"{doctor.Name} is added successfully");

                }
                else
                {
                    return BadRequest($"{doctor.Name} is Not successfully email already exists");
                }

            }
            else
            {
                return BadRequest($"image Not Added");

            }
        }
        [HttpGet("GetDoctorByspecialty")]
        public IActionResult GetDoctorsBySpecialty(string specialty)
        {
            var doctors = _mapper.Map<List<DoctorDTO>>(_repo.GetDoctorsBySPeciality(specialty));
            if (doctors != null)
            {
                return Ok(doctors);
            }
            else
            {
                return BadRequest("No doctors in that Specialty");
            }
        }
        [HttpGet("GetDoctorname")]
        public IActionResult GetDoctorsByName(string Name)
        {
            var doctors = _repo.GetDoctorsByName(Name);
            if (doctors != null)
            {
                return Ok(doctors);
            }
            else
            {
                return BadRequest("No doctors in that Specialty");
            }
        }
        [HttpGet("Log IN")]
        public IActionResult LogIn([FromQuery] string email,string password)
        {
            int doctorId=_repo.login(email, password);
            if (doctorId == 0)
            {
                return Ok("wrong email or password try again");
            }
            else
            {
                return Ok(doctorId);
            }

        }
    }
}
