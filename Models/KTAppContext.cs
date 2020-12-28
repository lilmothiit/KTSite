using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace KTSite.Models
{
    public class KTAppContext : IdentityDbContext
    {
        public DbSet<Favorites> Favorites { get; set; }
        public DbSet<Tab> Tabs { get; set; }
        public KTAppContext(DbContextOptions<KTAppContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // create the db on the first time
        }
    }
}
