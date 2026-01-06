using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Server.DTO;
using MovieApp.Server.Models;

namespace MovieApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private ApplicationDBContext _context;
        private UserManager<MovieUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public AccountController(ApplicationDBContext context, UserManager<MovieUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost("RegisterUser")]
        public async Task<ActionResult> RegisterUser(RegisterUserDTO userInput)
        {
            if (ModelState.IsValid)
            {
                var newUser = new MovieUser();
                newUser.UserName = userInput.Username;
                newUser.Email = userInput.Email;
              

                var result = await _userManager.CreateAsync(newUser, userInput.Password);

                if (result.Succeeded) 
                {
                    return StatusCode(201, $"New User {newUser.UserName} has been created");
                }
   
                
                
            }
            return BadRequest("User can't be created");
        }
    }
}
