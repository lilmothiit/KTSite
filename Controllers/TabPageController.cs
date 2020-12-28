using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KTSite.Cache;
using KTSite.Models;
using KTSite.Models.Interfaces;
using KTSite.Models.Handlers;
using KTSite.Models.ViewModels;


namespace KTSite.Controllers
{
    public class TabPageController : Controller
    {
        private readonly KTAppContext _appContext;
        private readonly ICacheService _cacheService;
        public TabPageController(KTAppContext appContext, ICacheService cacheService)
        {
            _appContext = appContext;
            _cacheService = cacheService;
        }
        public async Task<IActionResult> Tab(string tabID)
        {
            var tab = _appContext.Tabs.Where(x => x.TabID == tabID).FirstOrDefault();
            var tabPageView = new TabPageViewModel(tab);

            string cashedTime = await _cacheService.GetCacheValueAsync("FirstTimeVisited-"+tab.Name);

            if (string.IsNullOrEmpty(cashedTime))
            {
                await _cacheService.SetCacheValueAsync("FirstTimeVisited-"+tab.Name, DateTime.Now.ToString());
            }
            
            return View("/Views/TabPage/TabPage.cshtml", tabPageView);
        }
    }
}
