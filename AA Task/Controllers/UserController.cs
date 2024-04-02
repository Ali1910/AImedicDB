using AA_Task.DataContext;
using AA_Task.DTO;
using AA_Task.Interface;
using AA_Task.Models;
using AutoMapper;
using howtohandelimages.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

namespace AA_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _repo;
        private readonly iFileService _service;
        private readonly IMapper _mapper;
        public UserController(IUserRepo repo
            , IMapper mapper,iFileService service)
        {
            _mapper = mapper;
            _repo = repo;
            _service = service;
            
        }
        [HttpPost]
        public IActionResult SignUp([FromForm] UserDTO usermapper)
        {

            if (usermapper.image != null)
            {
                var result = _service.SaveImage(usermapper.image);
                if (result.Item1 == 1)
                {
                    var user = new User()
                    {
                        Email = usermapper.Email,
                        Name = usermapper.Name,
                        SpecialCondition = usermapper.SpecialCondition,
                        ProfilePic = result.Item2,
                        City = usermapper.City,
                        phoneNumber = usermapper.phoneNumber,
                        Password = usermapper.Password,
                        BirthDate = usermapper.BirthDate,
                        gender=usermapper.gender,

                    };
                    var checker = _repo.AddUser(user);
                    if (checker)
                    {
                        return Ok(usermapper);

                    }
                    else
                    {
                        return Ok($"{user.Email} already eisxt");
                    }
                }
                else
                {
                    return BadRequest($"image Not saved");
                }
                

                
                }else
                {
                    return BadRequest($"image Not Added");

                }
            
        }
        [HttpGet]
        public IActionResult login([FromQuery]string email,string password) 
        {
            var user=_repo.login(email,password);
            if(user == 0)
            {
                return Ok("Wrong email or passwrod try agin and make sure you entered the right password");
            }
            else
            {
                return Ok(user);
            }
            
        }
        [HttpGet("GetPofileDetailes")]
        public IActionResult profile([FromQuery] int id)
        {
            var user =  _repo.GetProfileDetials(id);
            if (user == null)
            {
                return Ok("Wrong Id");
            }
            else
            {
                var profiledata = new
                {
                    pic = user.ProfilePic,
                    name = user.Name,
                    email = user.Email
                };
                return Ok(profiledata);
            }

        }
    }
}
