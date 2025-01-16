using Sim.BL.DTOs.DepartmentDTOs;
using Sim.BL.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.BL.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        public Task CreateDepartmentAsync(DepartmentPostDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDepartment(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<DepartmentGetDTO>> GetAllDepartmentAsync()
        {
            throw new NotImplementedException();
        }

        public Task<DepartmentGetDTO> GetDepartmentByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDepartment(DepartmentPutDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
