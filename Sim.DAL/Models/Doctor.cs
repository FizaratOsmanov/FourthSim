using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.DAL.Models
{
    public class Doctor:BaseEntity
    {

        public string ImgPath { get; set; }

        public string Name { get; set; }

        public int? DepartmentId {  get; set; }

        public Department? Department { get; set; }
    }
}
