using AA_Task.Interface;
using AA_Task.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AA_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodyPartController : ControllerBase
    {
        private readonly IBodypartRepository _repo;
        public BodyPartController(IBodypartRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult GetBodyPart()
        {
            try
            {
                List<BodyPart> bodyParts = _repo.GetBodyPart();
                return Ok(bodyParts);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpPost]
        public IActionResult PostBodyPart([FromQuery] string bodypartName)
        {
            bool checler=_repo.addBodypart(bodypartName);
            if(checler)
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
