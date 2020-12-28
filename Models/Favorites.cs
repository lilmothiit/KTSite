using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace KTSite.Models
{
    public class Favorites
    {
        public Favorites()
        {
            UserID = "";
            JSONTabs = "[]";
        }

        public Favorites(string userId)
        {
            UserID = userId;
            JSONTabs = "[]";
        }

        [Key]
        public string UserID { get; set; }

        public string JSONTabs { get; set; }
    }
}
