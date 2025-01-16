using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sim.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.DAL.Contexts
{
    public class AppDbContext:IdentityDbContext<IdentityUser, IdentityRole,string>
    {
        public AppDbContext(DbContextOptions opt):base(opt) { }

        public DbSet<Department> Categories { get; set; }

        public DbSet<Doctor> Doctors { get; set; }
    }
}
