using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KTSite.Models
{
    public class Tab
    {
        [Key]
        public string TabID { get; set; }

        public string FileUrl { get; set; }

        public string Name { get; set; }

        public string Genre { get; set; }

        public string Author { get; set; }

        public float Rating { get; set; }
    }
}
