using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using LoginRelease.Data;
using Microsoft.AspNetCore.Mvc;
using LoginRelease.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace LoginRelease.Controllers
{
    public class HomeController : Controller
    {
       

        private readonly UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private ApplicationDbContext _applicationDbContext;


        public HomeController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext applicationDbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details()
        {
            ViewData["Message"] = "Your application description page.";
            var users = _applicationDbContext.Users.ToList();
            
//            foreach (ApplicationUser applicationUser in users)
//            {
//                if (!applicationUser.IsEnable)
//                {
//                    await _userManager.SetLockoutEnabledAsync(applicationUser, true);
//                    applicationUser.LockoutEnabled = true;
//                    applicationUser.LockoutEnd = DateTimeOffset.Now;
//                }
//                else
//                {
//                    await _userManager.SetLockoutEnabledAsync(applicationUser, false);
//                    applicationUser.LockoutEnabled = false;
//                    applicationUser.LockoutEnd = DateTimeOffset.Now;
//                }
//                
//            }

            return View(users);
        }


        [Authorize(Roles = "Admin, manager")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [Authorize(Roles = "Admin, user, manager")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

//        public async Task<ActionResult> Edit()
//        {
//            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
//            if (user != null)
//            {
//                EditViewModel model = new EditViewModel {Id = user.Id, Name = user.UserName};
//                return View(model);
//            }
//            return RedirectToAction("Login", "Account");
//        }
//
//        [HttpPost]
//        public async Task<ActionResult> Edit(EditViewModel model)
//        {
//            ApplicationUser user = await _userManager.FindByEmailAsync(User.Identity.Name);
//            if (user != null)
//            {
//                IdentityResult result = await _userManager.UpdateAsync(user);
//                if (result.Succeeded)
//                {
//                    return RedirectToAction("Index", "Home");
//                }
//                else
//                {
//                    ModelState.AddModelError("", "Что-то пошло не так");
//                }
//            }
//            else
//            {
//                ModelState.AddModelError("", "Пользователь не найден");
//            }
//
//            return View(model);
//        }
//
//        [HttpGet]
//        public ActionResult Delete()
//        {
//            return View();
//        }
//
//        [HttpPost]
//        [ActionName("Delete")]
//        public async Task<ActionResult> DeleteConfirmed()
//        {
//            var users = await _userManager.FindByEmailAsync(User.Identity.Name);
//            if (users != null)
//            {
//                IdentityResult result = await _userManager.DeleteAsync(users);
//                if (result.Succeeded)
//                {
//                    return RedirectToAction("Logout", "Account");
//                }
//            }
//            return RedirectToAction("Index", "Home");
//        }


        public IActionResult Edit(UserManager<ApplicationUser> userManager)
        {
            if (!userManager.SupportsUserLockout)
            {
                
            }
            throw new NotImplementedException();
        }
    }
}