using Medicar_API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicar.Application.Dtos.GetDtos;

public class GetScheduleDto
{
   public int ScheduleId { get; set; }
    public DateTime Date { get; set; }
    public bool Available { get; set; }
    public GetDoctorDto Doctor { get; set; }
    public ICollection<GetSlotDto> Slots { get; set; }
}
