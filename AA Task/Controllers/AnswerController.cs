using AA_Task.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AA_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerRepo _Repo;
        public AnswerController(IAnswerRepo Repo)
        {
            _Repo = Repo;
        }
        [HttpPost]
        public IActionResult AnswerQuestion([FromQuery] string content, int doctorId, int QuestionId)
        {
            Tuple<bool, string> response = _Repo.answerQuestion(doctorId, QuestionId, content);
            if(response.Item1 == true)
            {
                return Ok(response.Item2);
            }else 
            {
                return BadRequest(response.Item2);
            }

        }
        
    }
}
