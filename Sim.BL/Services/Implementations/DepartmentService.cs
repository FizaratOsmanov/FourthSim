using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Sim.BL.DTOs.DepartmentDTOs;
using Sim.BL.DTOs.DoctorDTOs;
using Sim.BL.Services.Abstractions;
using Sim.DAL.Models;
using Sim.DAL.Repositories.Abstractions;
using Sim.DAL.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Sim.BL.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }
        public async Task CreateDepartmentAsync(DepartmentPostDTO dto)
        {
            Department department=_mapper.Map<Department>(dto);
            await _departmentRepository.AddAsync(department);
            int result = await _departmentRepository.SaveChangesAsync();
            if (result == 0)
            {
                throw new Exception("Cannot add department.");
            }
        }

        public async Task DeleteDepartment(int id)
        {
            Department doctor = await _departmentRepository.GetByIdAsync(id);
            if (doctor == null)
            {
                throw new Exception("Department is not found");
            }
            _departmentRepository.Delete(doctor);

            int result = await _departmentRepository.SaveChangesAsync();
            if (result == 0)
            {
                throw new Exception("Something went wrong");
            }
        }

        public async Task<ICollection<DepartmentGetDTO>> GetAllDepartmentAsync()
        {
            var department = await _departmentRepository.GetAllAsync();

            return _mapper.Map<ICollection<DepartmentGetDTO>>(department);
        }

        public async Task<Department> GetDepartmentByIdAsync(int Id)
        {
            Department department = await _departmentRepository.GetByIdAsync(Id);
            return department;
        }

        public async Task UpdateDepartment(DepartmentPutDTO dto)
        {
            Department department = await _departmentRepository.GetByConditionAsync(d => d.Id == dto.Id);

            _departmentRepository.Update(department);
            int result = await _departmentRepository.SaveChangesAsync();
        }
    }
}
