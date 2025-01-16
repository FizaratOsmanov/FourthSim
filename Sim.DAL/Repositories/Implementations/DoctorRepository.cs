using Sim.DAL.Contexts;
using Sim.DAL.Models;
using Sim.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.DAL.Repositories.Implementations
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(AppDbContext context) : base(context)
        {
        }
    }
}
