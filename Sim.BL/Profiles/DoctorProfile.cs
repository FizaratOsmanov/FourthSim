using AutoMapper;
using Sim.BL.DTOs.DoctorDTOs;
using Sim.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.BL.Profiles
{
    public class DoctorProfile:Profile
    {
        public DoctorProfile()
        {
            CreateMap<DoctorGetDTO,Doctor>().ReverseMap();
            CreateMap<DoctorPostDTO,Doctor>().ReverseMap();
            CreateMap<DoctorPutDTO,Doctor>().ReverseMap();
            CreateMap<DoctorGetDTO, DoctorPutDTO>().ReverseMap();
        }
    }
}
