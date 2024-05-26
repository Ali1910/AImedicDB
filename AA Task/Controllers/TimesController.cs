using AA_Task.Interface;
using BookingPage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AA_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimesController : ControllerBase
    {
        private readonly ITimesRepo _repo;
        public TimesController(ITimesRepo repo)
        {
            _repo = repo;
        }
        [HttpPost]
        public IActionResult EnterDate([FromQuery] string y, string m, string d)
        {
            bool checker = _repo.addTime(y, m, d);
            if (checker)
            {
                return Ok("added");
            }
            else { return BadRequest(); }
        }
        [HttpGet]
        public IActionResult GetTimes()
        {
            
           List<Times> times=_repo.GetTimes();
            return Ok(times);
        }
    }
}
