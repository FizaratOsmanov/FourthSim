using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sim.BL.DTOs.DoctorDTOs;
using Sim.BL.Services.Abstractions;
using Sim.DAL.Models;

namespace Sim.PL.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DoctorController : Controller
    {
        readonly IDoctorService _doctorService;
        readonly IDepartmentService _departmentService;
        readonly IMapper _mapper;
        public DoctorController(IDoctorService doctorService, IMapper mapper, IDepartmentService departmentService)
        {
            _doctorService = doctorService;
            _mapper = mapper;
            _departmentService = departmentService;
        }
        public async Task<IActionResult> Index()
        {
            ICollection<DoctorGetDTO> dto=await _doctorService.GetAllDoctorAsync();
            return View(dto);
        }
        public IActionResult Create()
        {
            ViewBag.Department = _departmentService.GetAllDepartmentAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DoctorPostDTO dto)
        {
            await _doctorService.CreateDoctorAsync(dto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _doctorService.DeleteDoctor(id);
            return RedirectToAction("Index");
        }


























        public async Task<IActionResult> Update(int Id)
        {
            var doctor =await _doctorService.GetDoctorByIdAsync(Id);
            DoctorPutDTO dto = _mapper.Map<DoctorPutDTO>(doctor);
            await _departmentService.GetAllDepartmentAsync();
            return View(dto);
        }


        [HttpPost]
        public async Task<IActionResult> Update(DoctorPutDTO dto)
        {
            await _doctorService.UpdateDoctor(dto);
            return RedirectToAction("Index");
        }
    }
}

