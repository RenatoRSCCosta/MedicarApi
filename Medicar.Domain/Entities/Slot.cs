using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicar_API.Domain.Entities;

public class Slot
{
    public int SlotId { get; set; }
    public TimeOnly Hour { get; set; }
    public bool Available { get; set; }
    public int ScheduleId { get; set; }
    public Schedule Schedule { get; set; }
    public ICollection<Consultation> Consultations { get; set; }
}