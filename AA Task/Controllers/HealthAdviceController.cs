using AA_Task.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AA_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthAdviceController : ControllerBase
    {
        private readonly IHealthAdviceRepo _repo;
        public HealthAdviceController(IHealthAdviceRepo repo)
        {
            _repo = repo;
            
        }
        [HttpPost]
        public IActionResult Post([FromQuery] int doctorId,string content)
        {
            bool checker=_repo.postHealthAdvice(doctorId, content);
            if (checker)
            {
                return Ok("تم أضافة النصيحة بنجاح");
            }
            else
            {
                return BadRequest("لم يتم أضافة النصيحة حاول مرة أخرى");
            }

        }
        [HttpGet]
        public IActionResult Get([FromQuery] int pageNum,int pagesize)
        {
            try {
                Dictionary<string, dynamic> response = _repo.GetAllHealthAvices(pageNum, pagesize);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            

        }
        [HttpPut]
        public IActionResult updateHealthAdvice([FromQuery] string content,int healthadviceId) 
        {
            bool checker = _repo.UpdateHealthAdvice(healthadviceId, content);
            if (checker)
            {
                return Ok("تم تعديل النصيحة");
            }
            else
            {
                return BadRequest("حدث خطأ أثناء التعديل حاول مرة اخرى");
            }
        }
        [HttpDelete]
        public IActionResult deleteHealthAdvice([FromQuery]int healthadviceId)
        {
            bool checker = _repo.deleteHealthAdvice(healthadviceId);
            if (checker)
            {
                return Ok("تم حذف النصيحة");
            }
            else
            {
                return BadRequest("حدث خطأ أثناء الحذف حاول مرة اخرى");
            }
        }
    }
}
