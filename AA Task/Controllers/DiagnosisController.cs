using AA_Task.Interface;
using AA_Task.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AA_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosisController : ControllerBase
    {
        private readonly IdiagnosisSummary _repo;

        public DiagnosisController(IdiagnosisSummary repo)
        {
            _repo=repo;
        }
        [HttpPost]
        public IActionResult Post([FromBody] diagnosis body) 
        { 
            bool checker=_repo.addDiagnoses(body);
            if (checker) {
                return Ok("تم الأضافة بنجاح");
            }
            else
            {
                return BadRequest("فشل الأضافة");
            }
        }
    }
}
