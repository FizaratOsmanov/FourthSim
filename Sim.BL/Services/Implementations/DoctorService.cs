using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Sim.BL.DTOs.DoctorDTOs;
using Sim.BL.Services.Abstractions;
using Sim.DAL.Models;
using Sim.DAL.Repositories.Abstractions;

namespace Sim.BL.Services.Implementations
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public DoctorService(IDoctorRepository doctorRepository,IMapper mapper,IWebHostEnvironment webHostEnvironment)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            
        }

        public async Task CreateDoctorAsync(DoctorPostDTO dto)
        {
            string rootPath = _webHostEnvironment.WebRootPath;
            string folder = rootPath + "/Uploads/Doctors/";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string fileName = dto.Image.FileName;

            string[] extensions = [".jpg", ".png", "jpeg"];
            bool isAllowed = false;
            foreach (var extension in extensions)
            {
                if (Path.GetExtension(fileName) == extension)
                {
                    isAllowed = true;
                    break;
                }
            }

            if (!isAllowed)
            {
                throw new Exception("File is not supported.");
            }

            string filePath = folder + fileName;

            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                await dto.Image.CopyToAsync(stream);
            }

            Doctor doctor = _mapper.Map<Doctor>(dto);
            doctor.ImgPath = fileName;

            await _doctorRepository.AddAsync(doctor);

            int result = await _doctorRepository.SaveChangesAsync();
            if (result == 0)
            {
                throw new OperationCanceledException("Couldn't create doctor.");
            }
        }

        public async Task DeleteDoctor(int id)
        {
            Doctor doctor=await _doctorRepository.GetByIdAsync(id);
            if (doctor == null)
            {
                throw new Exception("Doctor is not found");
            }

            _doctorRepository.Delete(doctor);

            int result=await _doctorRepository.SaveChangesAsync();
            if(result == 0)
            {
                throw new Exception("Something went wrong");
            }
        }

        public async Task<ICollection<DoctorGetDTO>> GetAllDoctorAsync()
        {
            var news = await _doctorRepository.GetAllAsync();

            return _mapper.Map<ICollection<DoctorGetDTO>>(news);
        }

        public async Task<DoctorGetDTO> GetDoctorByIdAsync(int Id)
        {
            Doctor doctor = await _doctorRepository.GetByIdAsync(Id);
            DoctorGetDTO dto = _mapper.Map<DoctorGetDTO>(doctor);
            return dto;
        }

        public async Task UpdateDoctor(DoctorPutDTO dto)
        {
            Doctor doctor = await _doctorRepository.GetByConditionAsync(d => d.Id == dto.Id);
            if (doctor is null)
            {
                throw new Exception("Couldn't find doctor.");
            }

            string rootPath = _webHostEnvironment.WebRootPath;
            string folder = Path.Combine(rootPath, "UPLOAD", "Doctors");
            string fileName = dto.Image.FileName;
            string[] extensions = { ".jpg", ".png", ".jpeg" };
            if (!extensions.Contains(Path.GetExtension(fileName).ToLower()))
            {
                throw new Exception("File is not supported.");
            }
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string filePath = Path.Combine(folder, fileName);

            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                await dto.Image.CopyToAsync(stream);
            }

            doctor.ImgPath = "/UPLOAD/Doctors/" + fileName; 
            _doctorRepository.Update(doctor);
            int result = await _doctorRepository.SaveChangesAsync();
            if (result == 0)
            {
                throw new Exception("Couldn't update doctor.");
            }
        }
    }
}
