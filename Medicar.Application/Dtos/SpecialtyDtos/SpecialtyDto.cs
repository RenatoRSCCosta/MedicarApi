using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicar.Application.Dtos.SpecialtyDtos;

public class SpecialtyDto
{
    public int SpecialtyId { get; set; }
    public string? Name { get; set; }
}
