using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KTSite.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KTSite.Models.Handlers
{
    public class TabHandler : ITabHandler
    {
        private readonly KTAppContext _appContext;

        public TabHandler(KTAppContext appContext, UserManager<IdentityUser> userManager)
        {
            _appContext = appContext;
        }

        public IEnumerable<Tab> Tabs => _appContext.Tabs;
    }
}
