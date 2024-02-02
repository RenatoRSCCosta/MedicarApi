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
    Task<CustomReturn<DoctorDto>> GetAll();
    Task<CustomReturn<DoctorDto>> GetById(int id);
    Task<CustomReturn<PostDoctorDto>> Add(PostDoctorDto doctor);
    Task<CustomReturn<DoctorDto>> Update(DoctorDto doctor);
    Task<CustomReturn<DoctorDto>> Delete(int id);

}
