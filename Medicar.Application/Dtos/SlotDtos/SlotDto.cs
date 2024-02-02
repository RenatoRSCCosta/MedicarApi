using Medicar_API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicar.Application.Dtos.SlotDtos
{
    public class SlotDto
    {
        public int SlotId { get; set; }
        public string? Hour { get; set; }
        public bool Available { get; set; }
        public int ScheduleId { get; set; }
    }
}
