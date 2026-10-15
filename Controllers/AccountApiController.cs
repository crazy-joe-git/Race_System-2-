using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Race_System_2_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountApiController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountApiController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public class RegisterModelDto
        {
            public string Email { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
            public string Role { get; set; } = "Participant"; // Organiser or Participant
        }

        public class LoginModelDto
        {
            public string Email { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
        }

        // POST: api/Account/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModelDto model)
        {
            var user = new IdentityUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(model.Role))
                {
                    await _userManager.AddToRoleAsync(user, model.Role);
                }
                return Ok(new { message = $"User registered successfully as {model.Role}!" });
            }
            return BadRequest(result.Errors);
        }

        // POST: api/Account/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModelDto model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return Ok(new { message = "Logged in successfully via API!" });
            }
            return Unauthorized(new { message = "Invalid login attempt." });
        }
    }
}