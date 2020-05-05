using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Data
{
    public class ApplicationUserDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationUserDbContext(DbContextOptions<ApplicationUserDbContext> options) : base(options)
        {

        }
    }
}
