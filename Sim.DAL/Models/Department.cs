﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.DAL.Models
{
    public class Department:BaseEntity
    {

        public string Title { get; set; }
        public string? Description { get; set; }

        public ICollection<Doctor>? Doctors { get; set; }
    }
}
