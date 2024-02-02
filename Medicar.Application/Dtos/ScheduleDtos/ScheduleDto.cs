using Medicar.Application.Dtos.DoctorDtos;
using Medicar.Application.Dtos.SlotDtos;
using Medicar_API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicar.Application.Dtos.ScheduleDtos
{
    public class ScheduleDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool Available { get; set; }
        public DoctorDto? Doctor { get; set; }
        public ICollection<SlotDto>? Slots { get; set; }
    }
}
