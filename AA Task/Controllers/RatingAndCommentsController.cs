using AA_Task.Interface;
using AA_Task.Models;
using AA_Task.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AA_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingAndCommentsController : ControllerBase
    {
        private readonly IratingAndCommentRepo _repo;
        public RatingAndCommentsController(IratingAndCommentRepo repo)
        {
            _repo = repo;
        }
        [HttpPost]
        public IActionResult Post([FromQuery] int doctorid, int appointmnetId, int userId, string rating, string? comment) { 
            bool checker=_repo.addrating(doctorid,appointmnetId,userId,rating,comment);
            try
            {
                if (checker)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            

        }
    }
}
