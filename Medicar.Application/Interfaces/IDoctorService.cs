using Medicar.Application.Dtos.GetDtos;
using Medicar.Application.Dtos.PostDtos;
using Medicar.Domain.Return;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicar.Application.Interfaces;

public interface IDoctorService
{
    Task<CustomReturn<GetDoctorDto>> GetAllDoctors();
    Task<CustomReturn<GetDoctorDto>> GetDoctorById(int id);
    Task<CustomReturn<PostDoctorDto>> CreateDoctor(PostDoctorDto doctor);
    Task<CustomReturn<PutDoctorDto>> UpdateDoctor(PutDoctorDto doctor);
    Task<CustomReturn<GetDoctorDto>> DeleteDoctor(int id);

}
