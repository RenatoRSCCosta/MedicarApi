using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicar.Application.Dtos.GetDtos;

public class GetDoctorDto
{
    public int DoctorId { get; set; }
    public string Name { get; set; }
    public string Crm { get; set; }
    public string Email { get; set; }
    public GetSpecialtyDto Specialty { get; set; }
}
