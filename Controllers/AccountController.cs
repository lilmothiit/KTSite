using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using KTSite.Models.ViewModels;
using KTSite.Models;
using KTSite.Models.Handlers;
using KTSite.Models.Interfaces;
using Newtonsoft.Json;
using System.Collections;

namespace KTSite.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly KTAppContext _appContext;
        private readonly ITabHandler _tabHandler;

        public AccountController(
            UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager, 
            KTAppContext appContext, 
            ITabHandler tabHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appContext = appContext;
            _tabHandler = tabHandler;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {                
                return View(loginViewModel);
            }

            var user = await _userManager.FindByNameAsync(loginViewModel.UserName);

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(loginViewModel);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var newUser = new IdentityUser() { UserName = registerViewModel.UserName };
                var result = await _userManager.CreateAsync(newUser, registerViewModel.Password);

                var newFavorites = new Favorites(newUser.Id);
                _appContext.Favorites.Add(newFavorites);
                _appContext.SaveChanges();

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(registerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult UserPage()
        {
            var favorites = _appContext.Favorites.Find(_userManager.GetUserId(User));
            var jsonString = JsonConvert.DeserializeObject<List<string>>(favorites.JSONTabs);
            List<Tab> userTabs = new List<Tab>();

            foreach(var str in jsonString)
            {
                userTabs.Add(_appContext.Tabs.Find(str));
            }

            var tabView = new UserPageViewModel
            {
                UserTabs = userTabs
            };

            return View(tabView);
        }
    }
}
