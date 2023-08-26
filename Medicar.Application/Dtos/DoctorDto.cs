using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicar.Application.Dtos;

public class DoctorDto
{
    public int DoctorId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Crm { get; set; }
    public string Email { get; set; }
    [Required]
    public int SpecialtyId { get; set; }
    public SpecialtyDto Specialty { get; set; }

}
