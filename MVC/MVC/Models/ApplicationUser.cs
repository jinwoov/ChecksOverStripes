using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public int JordanSeries { get; set; }
    }
}
