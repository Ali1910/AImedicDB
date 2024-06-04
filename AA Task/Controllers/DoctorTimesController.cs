using AA_Task.Interface;
using BookingPage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AA_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorTimesController : ControllerBase
    {
        private readonly IdoctorTimes _repo;
        public DoctorTimesController(IdoctorTimes repo)
        {
            _repo = repo;
        }
        [HttpPost]
        public IActionResult addTime([FromBody] DoctorTimes doctortime)
        {
            bool checker=_repo.addDoctortimes(doctortime);
            if(checker)
            {
                return Ok("تم أضافة مواعيدك بنجاح");
            }
            else
            {
                return BadRequest("أنت تملك مواعيد في هذا الوقت بالفعل");
            }
        }
        [HttpDelete]
        public IActionResult DeleteTimeById([FromQuery] int id)
        {
            bool checker=_repo.deleteDoctorTime(id);
            if (checker)
            {
                return Ok("تم الحذف");
            }
            else
            {
                return BadRequest();
            }

        }
        [HttpDelete("DeleteTimesForDoctor")]
        public IActionResult deleteTimesForDoctor([FromQuery] int id)
        {
            bool checker =_repo.deleteTimesForDoctor(id);
            if(checker)
            {
                return Ok("تم الحذف");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
