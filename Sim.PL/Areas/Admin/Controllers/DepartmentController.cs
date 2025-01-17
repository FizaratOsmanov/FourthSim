using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sim.BL.DTOs.DepartmentDTOs;
using Sim.BL.DTOs.DoctorDTOs;
using Sim.BL.Services.Abstractions;
using Sim.DAL.Models;

namespace Sim.PL.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DepartmentController : Controller
    {
        readonly IDoctorService _doctorService;
        readonly IDepartmentService _departmentService;
        readonly IMapper _mapper;
        public DepartmentController(IDoctorService doctorService, IMapper mapper, IDepartmentService departmentService)
        {
            _doctorService = doctorService;
            _mapper = mapper;
            _departmentService = departmentService;
        }

        public async Task<IActionResult> Index()
        {
            ICollection<DepartmentGetDTO> dto = await _departmentService.GetAllDepartmentAsync();
            return View(dto);
        }

        public IActionResult Create()
        {
            ViewBag.Department = _departmentService.GetAllDepartmentAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DepartmentPostDTO dto)
        {
            await _departmentService.CreateDepartmentAsync(dto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _departmentService.DeleteDepartment(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int Id)
        {
            Department department = await _departmentService.GetDepartmentByIdAsync(Id);
            DepartmentPutDTO dto = _mapper.Map<DepartmentPutDTO>(department);
            return View(dto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(DepartmentPutDTO dto)
        {
            await _departmentService.UpdateDepartment(dto);
            return View("Index");
        }
    }
}
