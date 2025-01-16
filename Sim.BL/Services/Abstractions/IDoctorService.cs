using Sim.BL.DTOs.DoctorDTOs;
using Sim.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.BL.Services.Abstractions
{
    public interface IDoctorService
    {
        Task<ICollection<DoctorGetDTO>> GetAllDoctorAsync();
        Task<DoctorGetDTO> GetDoctorByIdAsync(int Id);
        Task CreateDoctorAsync(DoctorPostDTO dto);
        Task UpdateDoctor(DoctorPutDTO dto);
        Task DeleteDoctor(int id);
    }
}
