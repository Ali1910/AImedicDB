using AA_Task.DTO;
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
        [HttpGet("GetUserDoneAppointments")]
        public IActionResult getUserDoneAppointmnets([FromQuery] int userId)
        {
            try
            {
                List<AppointmenstDTO> response = _repo.GetUserDoneAppointments(userId);
                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpGet("GetDoctorAppointments")]
        public IActionResult getDoctorAppointmnets([FromQuery] int doctorId,bool state)
        {
            try
            {
                List<AppointmenstDTO> response = _repo.GetDoctorAppointments(doctorId,state);
                return Ok(response);

            }
            catch (Exception ex)
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
            bool checker = _repo.deleteAppointment(AppontmentId);
            if (checker)
            {
                return Ok(checker);
            }
            else
            {
                return Ok(checker);
            }
            
        }
        [HttpPut]
        public IActionResult updateAppointment([FromQuery] int timeid , int AppointmentId, string appointmentime)
        {
            bool checker=_repo.UpdateAppointment(timeid,AppointmentId, appointmentime);
            if (checker)
            {
                return Ok(checker);
            }
            else
            {
                return Ok(checker);

            }
            

        }
        [HttpPut("endAppointMent")]
        public IActionResult EndAppointment([FromQuery]  int AppointmentId)
        {
            bool checker = _repo.EndAppointment(AppointmentId);
            if (checker)
            {
                return Ok(checker);
            }
            else
            {
                return Ok(checker);

            }


        }
    }
}
