using AA_Task.DTO;
using AA_Task.Interface;
using AA_Task.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AA_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialityController : ControllerBase
    {
        private readonly IspecialtyRepo _repo;
        private readonly IMapper _mapper;
        public SpecialityController(IspecialtyRepo repo,IMapper Mapper)
        {
            _repo = repo;
            _mapper = Mapper;
        }
        [HttpPost]
        public IActionResult CreateSpecialt([FromQuery] SpecialtyDTO specialtyMapper) 
        { 
            var checker= _repo.GetSpecialtyByName(specialtyMapper.Name);
            if (checker != null)
            {
                return BadRequest($"{checker.Name} you added already exists");
            }
            else
            {
                var specialty=_mapper.Map<Specialty>(specialtyMapper);
                var done = _repo.AddSpecialty(specialty);
                if (done)
                {
                    return Ok($"{specialty.Name} is added successfully");
                }
                else
                {
                    return BadRequest($"{specialty.Name} is not added");
                }
            }

        }
        [HttpGet]
        public IActionResult GetallSpecialties()
        {
            var specialtyList=_mapper.Map<List<SpecialtyDTO>>(_repo.GetSpecialties());
            if( specialtyList != null)
            {
                return Ok(specialtyList);
            }
            else
            {
                return BadRequest("No data to show");
            }
        }
        [HttpGet("GetSpecialtyByName")]
        public IActionResult GetallSpecialtyByName(string name)
        {
            var Specialty =_mapper.Map< SpecialtyDTO > (_repo.GetSpecialtyByName(name));
            if(Specialty != null)
            {
                return Ok(Specialty);
            }
            else
            {
                return BadRequest($"{name} you searched for does'nt exist");
            }
        }
    }
}
