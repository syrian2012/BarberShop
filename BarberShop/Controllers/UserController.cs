using AutoMapper;
using BarberShop.Dto;
using BarberShop.Interfaces;
using BarberShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateBarber([FromQuery] string mobileNumber, [FromQuery] string password)
        {
            if (mobileNumber == null || password == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_userRepository.Login(mobileNumber,password))
            {
                ModelState.AddModelError("", "Invaled Mobile Number Or Bad Password");
                return StatusCode(500, ModelState);
            }

            return Ok("Login Success");
        }
    }
    
}
