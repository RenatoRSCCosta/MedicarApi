using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicar.Application.Dtos.ScheduleDtos;

public class PostScheduleDto
{
    [Required]
    public int DoctorId { get; set; }
    [Required]
    public DateTime Date { get; set; }
}
