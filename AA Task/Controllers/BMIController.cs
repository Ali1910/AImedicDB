using AA_Task.Interface;
using AA_Task.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AA_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BMIController : ControllerBase
    {
        private readonly IBMI _repo;
        public BMIController(IBMI repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public IActionResult Post([FromBody] BMI bmi)
        {
            bool checker=_repo.addBMIValue(bmi);
            if(checker)
            {
                return Ok("تم أضافة القيمة بنجاح");
            }
            else
            {
                return BadRequest("حدث خطأ حاول مرة أخرى");
            }
        }
        [HttpGet]
        public IActionResult Get([FromQuery] int userId)
        {
            try
            {
                float bmi = _repo.getBMILastValue(userId);
                return Ok(bmi);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
           
        }
        [HttpGet("BMI Reads For user")]
        public IActionResult GetBMireadsForUser([FromQuery] int userId)
        {
            try
            {
                List<BMI> bmi = _repo.getBMIReadsForUser(userId);
                return Ok(bmi);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }

        }
        [HttpDelete]
        public IActionResult DeleteBMiRead([FromQuery] int BMIId)
        {
            bool chexker=_repo.DeleteBMIRead(BMIId);
            if (chexker)
            {
                return Ok();
            }else { return BadRequest(); }
        }
    }
}
