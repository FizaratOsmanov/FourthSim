using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Sim.BL.DTOs.DoctorDTOs;
using Sim.BL.Services.Abstractions;
using Sim.DAL.Models;
using Sim.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Doctor doctor = _mapper.Map<Doctor>(dto);

            string rootPath = _webHostEnvironment.WebRootPath;
            string fileName = dto.Image.FileName;
            string folderPath = rootPath + "/UPLOAD/NEWs/";
            string filePath = Path.Combine(folderPath, fileName);

            bool exists = Directory.Exists(folderPath);

            if (!exists)
            {
                Directory.CreateDirectory(folderPath);
            }

            string[] allowedExtensions = [".png", ".jpg", ".jpeg"];
            bool isAllowed = false;
            foreach (string extention in allowedExtensions)
            {
                if (Path.GetExtension(fileName) == extention)
                {
                    isAllowed = true;
                    break;
                }
            }
            if (!isAllowed)
            {
                throw new Exception("File not supported");
            }

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await dto.Image.CopyToAsync(stream);
            }
            dto.Image = fileName;

            await _doctorRepository.AddAsync(doctor);
            int result = await _doctorRepository.SaveChangesAsync();
            if (result == 0)
            {
                throw new Exception("Couldnt added News.");
            }
        }

        public Task DeleteDoctor(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<DoctorGetDTO>> GetAllDoctorAsync()
        {
            throw new NotImplementedException();
        }

        public Task<DoctorGetDTO> GetDoctorByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDoctor(DoctorPutDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
