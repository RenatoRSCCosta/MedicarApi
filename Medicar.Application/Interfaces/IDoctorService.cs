using Medicar.Application.Dtos.DoctorDtos;
using Medicar.Domain.Return;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicar.Application.Interfaces;

public interface IDoctorService
{
    Task<CustomReturn<DoctorDto>> GetAllDoctors();
    Task<CustomReturn<DoctorDto>> GetDoctorById(int id);
    Task<CustomReturn<PostDoctorDto>> CreateDoctor(PostDoctorDto doctor);
    Task<CustomReturn<DoctorDto>> UpdateDoctor(DoctorDto doctor);
    Task<CustomReturn<DoctorDto>> DeleteDoctor(int id);

}
