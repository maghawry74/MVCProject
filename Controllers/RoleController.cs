using Kotabko.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Kotabko.Controllers
{
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> roleManager;  
        public RoleController(RoleManager<IdentityRole> _roleManager)
        {
            roleManager = _roleManager;
        }
        public IActionResult NewRole() 
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewRole(RoleViewModel roleModel)
        {
            if(ModelState.IsValid)
            {
                IdentityRole RoleModel=new IdentityRole();
                RoleModel.Name = roleModel.RoleName;
                await roleManager.CreateAsync(RoleModel);
                return RedirectToAction("login", "Account");
            }
            return View();
        }
    }
}
