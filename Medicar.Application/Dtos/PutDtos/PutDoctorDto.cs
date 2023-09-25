using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicar.Application.Dtos.GetDtos;

public class PutDoctorDto
{
    [Required]
    public int DoctorId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Crm { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public int SpecialtyId { get; set; }
    public GetSpecialtyDto Specialty { get; set; }
}
