using AA_Task.Interface;
using AA_Task.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AA_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SyptomsController : ControllerBase
    {
        private readonly ISymptomsRepo _repo;
        public SyptomsController(ISymptomsRepo repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult GetSyptomsForBodyPart([FromQuery] int id )
        {
            try
            {
                List<Symptom> symptoms = _repo.getSymptoms(id);
                return Ok(symptoms);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        public IActionResult PostSyptom([FromQuery] string bodypartName,string arabicNameForSyp,string englishNameForSyp)
        {
            bool checler = _repo.addsymptom(englishNameForSyp,arabicNameForSyp,bodypartName);
            if (checler)
            {
                return Ok("name added");
            }
            else
            {
                return BadRequest();
            }
        } 
    
    }
}
