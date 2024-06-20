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
        [HttpGet("GetDiagnosisForAuser")]
        public IActionResult GetForUser([FromQuery] int userid) {
            try {
                List<diagnosis> response=_repo.GetDiagnosesForUser(userid);
                return Ok(response);
            } catch
            {
                return BadRequest();
            }
        }
        [HttpGet("GetDiagnosisForADoctor")]
        public IActionResult GetForDoctor([FromQuery] int doctorid)
        {
            try
            {
                Dictionary<string,dynamic> response = _repo.GetDiagnosesForDoctor(doctorid);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        public IActionResult DeleteDiagnosis([FromQuery] int diagnosisId) { 
            bool checker=_repo.deleteDiagnosis(diagnosisId);
            if (checker) {
                return Ok("تم الحذف بنجاح");
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
