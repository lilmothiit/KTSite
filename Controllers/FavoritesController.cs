using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KTSite.Models;
using Newtonsoft.Json;

namespace KTSite.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly KTAppContext _appContext;
        private readonly UserManager<IdentityUser> _userManager;

        public FavoritesController(KTAppContext appContext, UserManager<IdentityUser> userManager)
        {
            _appContext = appContext;
            _userManager = userManager;
        }



        public IActionResult AddTab(string tabID)
        {
            var favorites = _appContext.Favorites.Find(_userManager.GetUserId(User));
            var jsonString = JsonConvert.DeserializeObject<List<string>>(favorites.JSONTabs);
            jsonString.Add(tabID);
            favorites.JSONTabs = JsonConvert.SerializeObject(jsonString);
            _appContext.Favorites.Update(favorites);
            _appContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult RemoveTab(string tabID)
        {
            var favorites = _appContext.Favorites.Find(_userManager.GetUserId(User));
            var jsonString = JsonConvert.DeserializeObject<List<string>>(favorites.JSONTabs);
            jsonString.Remove(tabID);
            favorites.JSONTabs = JsonConvert.SerializeObject(jsonString);
            _appContext.Favorites.Update(favorites);
            _appContext.SaveChanges();

            return RedirectToAction("UserPage", "Account");
        }
    }
}
