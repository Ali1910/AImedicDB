using AA_Task.DTO;
using AA_Task.Interface;
using AA_Task.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AA_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepo _questionRepo;
        private readonly IMapper _mapper;
        public QuestionController(IQuestionRepo questionRepo, IMapper mapper)
        {
            _mapper = mapper;
            _questionRepo = questionRepo;
            
            
        }
        [HttpPost]

        public IActionResult addPost([FromQuery] Question Que)
        {
            
            var checker =_questionRepo.addquestion(Que);
            if (checker)
            {
                return Ok("Question addedSuccessfully");
            }else { return BadRequest("check your Internet"); }

        }
        [HttpGet]
        public IActionResult GetAllGuestions([FromQuery] int pagesize,int pageNum) {
           var Questions= _questionRepo.getAllquestions(pagesize,pageNum);
            if (Questions.Count!=0) {
                return Ok(Questions);
            }
            else
            {
                return BadRequest("NO QuestionS To Show");
            }
            
        }
        [HttpGet("userQuestions")]
        public IActionResult GetAllGuestions([FromQuery]int id, int pagesize, int pageNum)
        {
            var listOfQuestions = _questionRepo.getMyQuestions(id, pagesize, pageNum);
            if (listOfQuestions.Count != 0)
            {
               return Ok(listOfQuestions);
                
            }
            else
            {
                return Ok("NO QuestionS To Show");
            }

        }
        [HttpDelete]
        public IActionResult Delete([FromQuery] int id) { 
            bool checker=_questionRepo.deletequestion(id);
            if (checker)
            { return Ok(); }
            else { return BadRequest(); }
        }
    }
}
