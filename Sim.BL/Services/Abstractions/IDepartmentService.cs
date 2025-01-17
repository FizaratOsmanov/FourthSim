using Sim.BL.DTOs.DepartmentDTOs;
using Sim.BL.DTOs.DoctorDTOs;
using Sim.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.BL.Services.Abstractions
{
    public interface IDepartmentService
    {
        Task<ICollection<DepartmentGetDTO>> GetAllDepartmentAsync();
        Task<Department> GetDepartmentByIdAsync(int Id);
        Task CreateDepartmentAsync(DepartmentPostDTO dto);
        Task UpdateDepartment(DepartmentPutDTO dto);
        Task DeleteDepartment(int id);
    }
}
