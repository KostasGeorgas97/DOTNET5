using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOTNET5.Models
{
    public class Universities
    {
        public int Id { get; set; }
        public string Country { get; set; } = "Greece";
        public string UniName { get; set; } = "University of Athens";
        public string UniWebpage { get; set; } = "https://www.uoa.gr";
    }
}