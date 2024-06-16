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
            , IMapper mapper, iFileService service)
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
                        gender = usermapper.gender,

                    };
                    var checker = _repo.AddUser(user);
                    if (checker)
                    {
                        return Ok(user);

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



            } else
            {
                return BadRequest($"image Not Added");

            }

        }
        [HttpGet]
       public IActionResult Login([FromQuery] string email,string password) 
        {
            int reponse=_repo.login(email, password);
            if(reponse == 0)
            {
                return BadRequest("تأكد من صحة البيانات المدخلة");
            }
            else
            {
                return Ok(reponse);
            }
        }
        [HttpGet("LoginUsingNfc")]
        public IActionResult LoginUsingNfc([FromQuery] string NFC)
        {
            int reponse = _repo.loginUsingNfc(NFC);
            if (reponse == 0)
            {
                return BadRequest("تأكد من صحة البيانات المدخلة");
            }
            else
            {
                return Ok(reponse);
            }
        }
        [HttpGet("GetPofileDetailes")]
        public IActionResult profile([FromQuery] int id)
        {
            var user = _repo.GetProfileDetials(id);
            if (user == null)
            {
                return Ok("Wrong Id");
            }
            else
            {
                
                return Ok(user);
            }

        }
        [HttpPut("updatePassword")]
        public IActionResult UpdatePassword([FromQuery] int id, string oldpassword, string newpassword)
        {
            try
            {
                string result = _repo.updatepassword(id, oldpassword, newpassword);
                if (result == "برجاء إدخال كلمة مرور القديمة بشكل صحيح")
                {
                    return Ok(result);
                }
                else
                {
                    return Ok(result);
                }

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("updateCity")]
        public IActionResult Updatecity ([FromQuery] int id,  string newcity)
        {
            try
            {
                string result = _repo.updateCity(id, newcity);
               
                    return Ok(result);
                
                

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("updatePhoneNumber")]
        public IActionResult UpdatePhoneNumber([FromQuery] int id, string newPhoneNumber)
        {
            try
            {
                string result = _repo.updatePhoneNumber(id, newPhoneNumber);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("AddNFC")]
        public IActionResult addNfcIdForUser([FromQuery] int id, string NFCid)
        {
            
            var checker=_repo.addNFCId(NFCid, id);
            if (checker.Item1)
            {
                return Ok(checker);
            }
            else
            {
                return BadRequest(checker);
            }
        }
        [HttpPut("UpdateProfilePic")]
        public IActionResult UpdateDoctorProfilePic([FromForm] int UserId, IFormFile? image)
        {
            bool checker = _repo.updateUserProfilePic(image, UserId);
            if (checker)
            {
                return Ok("تم تحديث الصورة الشخصية بنجاح");
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
