using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicar.Application.Dtos.GetDtos;

public class GetSpecialtyDto
{
    public int SpecialtyId { get; set; }
    public string Name { get; set; }
}
