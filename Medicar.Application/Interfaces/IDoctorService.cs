using Medicar.Application.Dtos.GetDtos;
using Medicar.Application.Dtos.PostDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicar.Application.Interfaces;

public interface IDoctorService
{
    Task<List<GetDoctorDto>> GetAllDoctors();
    Task<GetDoctorDto> GetDoctorById(int id);
    Task<PostDoctorDto> CreateDoctor(PostDoctorDto doctor);
    Task<PutDoctorDto> UpdateDoctor(PutDoctorDto doctor);
    Task DeleteDoctor(int id);

}
