using Medicar.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicar.Application.Interfaces;

public interface IDoctorService
{
    Task<List<DoctorDto>> GetAll();
    Task<DoctorDto> GetById(int id);
    Task<DoctorDto> CreateDoctor(DoctorDto doctor);
    Task<DoctorDto> UpdateDoctor(DoctorDto doctor);
    Task<DoctorDto> DeleteDoctor(int id);

}
