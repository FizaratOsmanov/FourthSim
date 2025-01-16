using AutoMapper;
using Sim.BL.DTOs.DepartmentDTOs;
using Sim.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.BL.Profiles
{
    public class DepartmentProfile:Profile
    {
        public DepartmentProfile()
        {
            CreateMap<DepartmentGetDTO,Department>().ReverseMap();
            CreateMap<DepartmentPostDTO,Department>().ReverseMap();
            CreateMap<DepartmentPutDTO,Department>().ReverseMap();
        }
    }
}
