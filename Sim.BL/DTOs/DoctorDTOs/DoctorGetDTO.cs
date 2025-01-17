using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.BL.DTOs.DoctorDTOs
{
    public class DoctorGetDTO
    {
        public int Id { get; set; }
        public string ImgPath { get; set; }
        public string Name { get; set; }

        public int? DepartmentId { get; set; }
    }
}
