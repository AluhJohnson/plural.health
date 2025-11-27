using Azure.Core;
using Microsoft.AspNetCore.Identity;
using plural.health.Contracts;
using plural.health.Data;
using plural.health.Domian.Models;
using plural.health.Infractures.Util;
using plural.health.UOW;
using plural.health.ViewModels;
using System.Net;

namespace plural.health.Services
{
    public class UserService //: Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        private ApplicationDbContext _context;

        private IConfiguration _configuration;

        private IWebHostEnvironment env;
        private readonly TokenService _token;

        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;
        private IPasswordHasher<ApplicationUser> passwordHasher;
        private RoleManager<IdentityRole> roleManager;
        public UserService(
            IUnitOfWork unitOfWork, 
            ApplicationDbContext context, 
            IConfiguration configuration, 
            IWebHostEnvironment env, 
            UserManager<ApplicationUser> userMgr, 
            SignInManager<ApplicationUser> signinMgr, 
            IPasswordHasher<ApplicationUser> passwordHash,
            RoleManager<IdentityRole> roleMgr,
            TokenService token
            )
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _configuration = configuration;
            this.env = env;

            userManager = userMgr;
            signInManager = signinMgr;
            passwordHasher = passwordHash;
            roleManager = roleMgr;
            _token = token;
        }
        public async Task<Response<LoginVM>> signIn(LoginVM login)
        {
            try
            {
                var appUser = await userManager.FindByEmailAsync(login.Email);
                if (appUser == null)
                    return new Response<LoginVM>
                    {
                        Code = new ResponseStatusCode().NORECORDFOUND,
                        Message = "user not found"
                    };
                await signInManager.SignOutAsync();
                Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(appUser, login.Password, login.Remember, false);

                if (result.Succeeded)
                {
                    var t = _token.BuildToken(_configuration["Jwt:Key"].ToString(), _configuration["Jwt:Issuer"].ToString(), appUser);
                    return new Response<LoginVM>
                    {
                        Data = login,
                        Code = new ResponseStatusCode().SUCCESS,
                        Message = "Success"
                    };
                }

                return new Response<LoginVM>
                {
                    Code = new ResponseStatusCode().EXCEPTIONOCCOURED,
                    Message = "system malfunction"
                };
            }
            catch (Exception ex)
            {
                return new Response<LoginVM>
                {
                    Code = new ResponseStatusCode().EXCEPTIONOCCOURED,
                    Message = $"system malfunction||{ex.Message}"
                };
            }

        }

        public async Task<Response<(ApplicationUser?, IdentityResult?)>> New(RegistrationVM request, string callback)
        {
            try
            {
                var appUser = await userManager.FindByEmailAsync(request.Email);

                if (appUser != null)
                    return new Response<(ApplicationUser?, IdentityResult?)>
                    {
                        Code = new ResponseStatusCode().RECORDEXIST,
                        Message = "User email already exist please try again another email!"
                    };
                else
                {
                    var user = new ApplicationUser
                    {
                        Email = request.Email,
                        UserName = request.UserName,
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        PhoneNumber = request.PhoneNumber,
                    };

                    IdentityResult result = await userManager.CreateAsync(user, request.Password);

                    if (!result.Succeeded)
                        return new Response<(ApplicationUser?, IdentityResult?)>
                        {
                            Data = (null, result),
                            Code = new ResponseStatusCode().FAILED,
                            Message = "user not created"
                        };
                    result = await userManager.AddToRoleAsync(user, "Student");
                    if (!result.Succeeded)
                        return new Response<(ApplicationUser?, IdentityResult?)>
                        {
                            Data = (null, result),
                            Code = new ResponseStatusCode().USERROLEFAILED,
                            Message = "user role not created"
                        };

                    return new Response<(ApplicationUser?, IdentityResult?)>
                    {
                        Data = (appUser, result),
                        Code = new ResponseStatusCode().SUCCESS,
                        Message = "user created"
                    };

                }
            }
            catch (Exception ex)
            {
                return new Response<(ApplicationUser?, IdentityResult?)>
                {
                    Code = new ResponseStatusCode().EXCEPTIONOCCOURED,
                    Message = "Operation failed"
                };
            }
        }

        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }

        public async Task<Response<string>> TokenAuth(string? userId)
        {
            var user = _context.Users.Where(x => x.Id.Equals(userId)).FirstOrDefault();
            var appUser = new ApplicationUser
            {
                Email = user.Email,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
            };
            var tokin = _token.BuildToken(_configuration["Jwt:Key"].ToString(), _configuration["Jwt:Issuer"].ToString(), appUser);
            if (tokin != null)
                return new Response<string> { Data = tokin, Code = new ResponseStatusCode().NORECORDFOUND, Message = $"Success" };
            return new Response<string> { Code = new ResponseStatusCode().NORECORDFOUND, Message = $"no token generated" };

        }

        public string Test()
        {
            var rr = _context.UserRoles.ToList();

            return "Hell o test";
        }

    }

}
