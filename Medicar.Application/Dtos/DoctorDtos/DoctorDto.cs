using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicar.Application.Dtos.SpecialtyDtos;

namespace Medicar.Application.Dtos.DoctorDtos;

public class DoctorDto
{
    public int DoctorId { get; set; }
    public string? Name { get; set; }
    public string? Crm { get; set; }
    public string? Email { get; set; }
    public SpecialtyDto? Specialty { get; set; }
}
