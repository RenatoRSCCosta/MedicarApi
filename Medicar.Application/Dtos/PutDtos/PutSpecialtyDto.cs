using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicar.Application.Dtos.GetDtos;

public class PutSpecialtyDto
{
    [Required]
    public int SpecialtyId { get; set; }
    [Required]
    public string Name { get; set; }
}
