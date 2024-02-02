using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicar.Application.Dtos.PostDtos
{
    public class PostSlotDto
    {
        public string Hour { get; set; }
        public bool Available { get; set; }
        public int ScheduleId { get; set; }
    }
}
