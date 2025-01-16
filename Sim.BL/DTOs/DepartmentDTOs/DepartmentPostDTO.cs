using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.BL.DTOs.DepartmentDTOs
{
    public class DepartmentPostDTO
    {
        public string Title { get; set; }
        public string? Description { get; set; }
    }
}
