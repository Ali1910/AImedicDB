using AA_Task.DTO;
using AA_Task.Models;
using AutoMapper;

using Microsoft.AspNetCore.Mvc;


namespace school.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentContoller : ControllerBase
    {
        private readonly IAppointmentRepository _repo;
        private readonly IMapper _mapper;
        public AppointmentContoller(IAppointmentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;

        }
        [HttpGet]
        public IActionResult GetTimesForDoctorInAdate([FromQuery] int doctorId, string year, string month, string day) {
            try
            {
                var ListOfTimes = _repo.getDoctorTimesforDate(doctorId, year, month, day);
                return Ok(ListOfTimes);
            }
            catch(Exception ex) {
                
                    return BadRequest(ex.ToString);

                
            }
            
       
        }
        [HttpGet("GetUserAppointments")]
        public IActionResult getUserAppointmnets([FromQuery] int userId, bool state)
        {
            try
            {
                List<AppointmenstDTO> doctors=_repo.GetUserAppointments(userId is EmptyResult ? 1:userId,state);
                return Ok(doctors);

            }catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpPost]
        public IActionResult BookAppointment([FromQuery] string appointmentime, int timeid, int UserId, int doctorId)
        {
           var appointment=_repo.addAppointment(appointmentime, timeid, UserId, doctorId);
            if (appointment)
            {
                return Ok("Appointment Added Successfully");
            }
            else
            {
                return BadRequest("Failed to add appointment");
            }
        }
        [HttpDelete]
        public IActionResult deleteAppointment([FromQuery] int AppontmentId) 
        {
            if (_repo.deleteAppointment(AppontmentId))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
            
        }
        [HttpPut]
        public IActionResult updateAppointment([FromQuery] string year, string day, string month, int AppointmentId, string appointmentime)
        {
            bool checker=_repo.UpdateAppointment(year, day, month, AppointmentId, appointmentime);
            if (checker)
            {
                return Ok(checker);
            }
            else
            {
                return BadRequest(checker);

            }

        }
    }
}
