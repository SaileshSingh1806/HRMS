using HRMS.Authentication;
using HRMS.Data;
using HRMS.DTO;
using HRMS.Models;
using HRMS.Models.Email;
using HRMS.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;
        private readonly HRMSDbContext context;
        private readonly IEmailService emailService;    
      

        public AuthenticationController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
            IConfiguration configuration,IEmailService emailService, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
            this.context = context;
            this.emailService = emailService;
            this.signInManager = signInManager;
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel registermodel, string role)
        {
            var userExist = await userManager.FindByNameAsync(registermodel.UserName);
            if (userExist != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists" });
            ApplicationUser user = new ApplicationUser()
            {
                Email = registermodel.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registermodel.UserName,
                TwoFactorEnabled = true
            };
            if(await roleManager.RoleExistsAsync(role))
            {
                var result = await userManager.CreateAsync(user, registermodel.Password);
                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User Creation Failed" });
                }
                //Add role to user..
                await userManager.AddToRoleAsync(user, role);
                // Token to Verify the Email
                var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                var ConfirmationLink = Url.Action(nameof(ConfirmEmail), "Authentication", new { token, email = user.Email }, Request.Scheme);
                var emailmessage = new EmailMessage(new string[] { user.Email! }, "Confirmation Email Link", ConfirmationLink!);
                emailService.SendEmail(emailmessage);
 
                return StatusCode(StatusCodes.Status201Created, new Response { Status = "Success", Message = $"User Created Successfully & Email Sent to {user.Email} Successfully" });

               

            }

            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Role Doesn't Exist" });
            }

         }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
    };
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                //TwoFactor
                if (user.TwoFactorEnabled)
                {
                    var token1 = await userManager.GenerateTwoFactorTokenAsync(user, "Email");

                    var message = new EmailMessage(new string[] { user.Email! }, "OTP Confirmation", token1);
                    emailService.SendEmail(message);

                    return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = $"We Have Sent an OTP To Your Email {user.Email}" });
                }

            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("Change-Password")]
        public async Task<ActionResult> ChangePassword([FromBody] ChangePasswordModel model)
        {

            var user = await userManager.FindByNameAsync(model.Username);
           var result = await userManager.ChangePasswordAsync(user, model.oldPassword, model.newPassword);
            if (result.Succeeded)
            {
                return Ok(new Response { Status = "Success", Message = "Password Changed Successfully" });
            }
            return Ok(new Response { Status = "Success", Message = "Password Changed Successfully" });
        }



        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var result = await userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Email Verified SuccessFully" });
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "This user doesn't exist" });
        }


        // Hash the password using a secure hashing algorithm (e.g., BCrypt)
        private string HashPassword(string password)
        {
            // Implement password hashing logic (use a library like BCrypt.Net)
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        
        [HttpPost]
        [Route("Login-2Factor")]
        public async Task<IActionResult> LoginWithOTP(string code, string username)
        {
            var user = await userManager.FindByNameAsync(username);
            var signIn = signInManager.TwoFactorSignInAsync("Email", code, false, false);
            var check = await userManager.VerifyTwoFactorTokenAsync(user, "Email", code);
            if (check == true)
            {
                if (signIn.IsCompleted)
                {
                    if (user != null)
                    {
                        var userRoles = await userManager.GetRolesAsync(user);

                        var authClaims = new List<Claim>
                     {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("sup", user.Id)
                      };
                        foreach (var userRole in userRoles)
                        {
                            authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                        }
                        var issuer = _configuration["Jwt:Issuer"];
                        var audience = _configuration["Jwt:Audience"];
                        var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
                        var signingCredentials = new SigningCredentials(
                                                new SymmetricSecurityKey(key),
                                                SecurityAlgorithms.HmacSha512Signature
                                            );
                        var subject = new ClaimsIdentity(new[]
{
new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
new Claim(JwtRegisteredClaimNames.Email, user.UserName),
new Claim("sup", user.Id),
});
                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = subject,
                            Expires = DateTime.UtcNow.AddMinutes(10),
                            Issuer = issuer,
                            Audience = audience,
                            SigningCredentials = signingCredentials
                        };

                        var tokenHandler = new JwtSecurityTokenHandler();
                        var token = tokenHandler.CreateToken(tokenDescriptor);
                        var jwtToken = tokenHandler.WriteToken(token);
                        return Ok(new
                        {
                            token = tokenHandler.WriteToken(token),
                            User = user.UserName
                        });
                    }
                }
            }
            return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Success", Message = $"Invalid Code" });
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("forgot-password")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var token = await userManager.GenerateTwoFactorTokenAsync(user, "Email");
                var forgetPasswordLink = token;
                var message = new EmailMessage(new string[] { user.Email! }, $"Your Password Reset Code Is", forgetPasswordLink!);
                emailService.SendEmail(message);

                return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = $"Change Password request is sent on Email {user.Email}. Please Check your email" });

            }
            return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = $"Couldnot send link to email, please try again." });
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Forgot-password-validate")]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel resetPassword, string code)
        {
            var user = await userManager.FindByEmailAsync(resetPassword.Email);
            if (user != null)
            {
                var check = await userManager.VerifyTwoFactorTokenAsync(user, "Email", code);
                if (check == true)
                {
                    var pass = await userManager.RemovePasswordAsync(user);
                    var Change = await userManager.AddPasswordAsync(user, resetPassword.Password);

                    return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = $"Password has been Changed " });
                }

            }
            return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = $"Please Check Your Details." });
        }
    }
}
