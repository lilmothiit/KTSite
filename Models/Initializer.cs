using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KTSite.Models
{
    public class Initializer
    {
        public void InitializeTabs(KTAppContext appContext)
        {
            appContext.Tabs.RemoveRange(appContext.Tabs);
            appContext.SaveChanges();

            appContext.AddRange
                (
                    new Tab
                    {
                        TabID = "0",
                        FileUrl = "mice-on-venus.txt",
                        Name = "Mice on Venus",
                        Genre = "Game OST",
                        Author = "C418",
                        Rating = 5
                    },
                    new Tab
                    {
                        TabID = "1",
                        FileUrl = "haggstrom.txt",
                        Name = "Haggstrom",
                        Genre = "Game OST",
                        Author = "C418",
                        Rating = 5
                    },
                    new Tab
                    {
                        TabID = "2",
                        FileUrl = "dry-hands.txt",
                        Name = "Dry Hands",
                        Genre = "Game OST",
                        Author = "C418",
                        Rating = 5
                    },
                    new Tab
                    {
                        TabID = "3",
                        FileUrl = "wet-hands.txt",
                        Name = "Wet Hands",
                        Genre = "Game OST",
                        Author = "C418",
                        Rating = 5
                    }
                );

            appContext.SaveChanges();
        }
        public void InitializeFavorites(KTAppContext appContext)
        {
            appContext.Favorites.RemoveRange(appContext.Favorites);
            appContext.SaveChanges();

            foreach(var user in appContext.Users)
            {
                if(appContext.Favorites.Find(user.Id) == null)
                {
                    var newFavorites = new Favorites(user.Id);
                    appContext.Favorites.Add(newFavorites);
                }
            }

            appContext.SaveChanges();
        }
    }
}
