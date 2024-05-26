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
        public IActionResult CreateDoctor([FromQuery] Doctor doctorMapper)
        {
           
        
                var checker=_repo.AddDoctor(doctorMapper);
                if (checker)
                {
                    return Ok($"{doctorMapper.Name} is added successfully");

                }
                else
                {
                    return BadRequest($"{doctorMapper.Name} is Not successfully email already exists");
                }

            }
            
        
        [HttpGet("GetDoctorByspecialty")]
        public IActionResult GetDoctorsBySpecialty(string specialty)
        {
            var doctors = _repo.GetDoctorsBySPeciality(specialty);
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
        public IActionResult GetDoctorsByName(string Name,string spec)
        {
            var doctors = _repo.GetDoctorsByName(Name,spec);
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
        [HttpGet]
        public IActionResult GetDoctorById([FromQuery]int id)
        {
            Doctor doctor = _repo.GetDoctorById(id);
            if(doctor == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(doctor);
            }
        }
        [HttpGet("patients")]
        public IActionResult GetPatientsForDoctor([FromQuery]int id)
        {
            List<User> users =_repo.getPateintsForDoctor(id);
            return Ok(users);
        }
    }
}
