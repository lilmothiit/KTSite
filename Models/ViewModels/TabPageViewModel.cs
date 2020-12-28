using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace KTSite.Models.ViewModels
{
    public class TabPageViewModel
    {
        public Tab Tab;
        public string parsedText;

        public TabPageViewModel(Tab tab)
        {
            Tab = tab;
            parsedText = System.IO.File.ReadAllText("~/../Database/TabsTXT/" + Tab.FileUrl);
        }
    }
}
