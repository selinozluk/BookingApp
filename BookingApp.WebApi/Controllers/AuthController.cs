using BookingApp.Business.Operations.User;
using BookingApp.Business.Operations.User.Dtos;
using BookingApp.WebApi.Jwt;
using BookingApp.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("register")]

        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
                // TO DO: İleride action filter olarak kodlanacak.
            }
            var addUserDto = new AddUserDto
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = request.Password,
                BirthDate = request.BirthDate,
            };
            var result = await _userService.AddUser(addUserDto);

            if (result.IsSucceed)
                return Ok(result.Message);
            else
                return BadRequest(result.Message);
        }
        //HTTPGET -> Veri Url üzerinden taşınır - querystring
        // -> Firewall ve benzeri uygulamalar url'i loglar, böyle bir durumda şifreyi de loglar.
        // GÜVENLİK AÇIĞI

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
                // TO DO: İleride action filter olarak kodlanacak.
            }

            var result = _userService.LoginUser(new LoginUserDto { Email = request.Email, Password = request.Password });

            if (!result.IsSucceed)
                return BadRequest(result.Message);

            var user = result.Data;
            var configuration = HttpContext.RequestServices.GetRequiredService<IConfiguration>();

            var token = JwtHelper.GenerateJwtToken(new JwtDto
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserType = user.UserType,
                SecretKey = configuration["Jwt:SecretKey"]!,
                Issuer = configuration["Jwt:Issuer"]!,
                Audience = configuration["Jwt:Audience"]!,
                ExpirationMinutes = int.Parse(configuration["Jwt:ExpirationMinutes"]!)
            });

            return Ok(new LoginResponse
            {
             
             Message = "Giriş başarıyla tamamlandı.",
             Token = token

            });
        }
    }
}
