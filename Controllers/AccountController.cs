using Kotabko.DataAccess;
using Kotabko.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.DependencyInjection;

namespace Kotabko.Controllers
{
    public class AccountController : Controller
    {   
        private readonly UserManager<ApplicationUser> UserManager;
        private readonly SignInManager<ApplicationUser> SignInManager;
        public AccountController(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager)
        {
            UserManager = _userManager;
            SignInManager = _signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Register
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel UserViewModel)
        {
            if(ModelState.IsValid==true)
            {
                ApplicationUser userModel = new ApplicationUser();
                userModel.UserName = UserViewModel.userName;
                userModel.PasswordHash = UserViewModel.password;
                userModel.governorate = UserViewModel.governorate;
                userModel.City = UserViewModel.city;
                userModel.Image = UserViewModel.Image;
                IdentityResult result=await UserManager.CreateAsync(userModel,UserViewModel.password);
                if (result.Succeeded)
                {
                   await SignInManager.SignInAsync(userModel,false);
                    
                    await  UserManager.AddToRoleAsync(userModel,"User");
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("",item.Description);
                    }
                    
                }

            }
           
            return View(UserViewModel);
            
        }
        #endregion
     
        #region login
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if(ModelState.IsValid) 
            {
               ApplicationUser userModel= await UserManager.FindByNameAsync(loginViewModel.userName);
                if (userModel != null) 
                {

                  var result= await SignInManager.PasswordSignInAsync(userModel,loginViewModel.password, loginViewModel.remmemberMe, false);
                  if(result.Succeeded)
                    {

                        //redirect to action 
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "UserName or Password wrong");
                    }

                }
                else
                {
                    ModelState.AddModelError("", "UserName or Password wrong");
                }
            }
            return View(loginViewModel);
        }
        #endregion

      
        #region logout

        public IActionResult Logout()
        {
            SignInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        #endregion
    }
}
