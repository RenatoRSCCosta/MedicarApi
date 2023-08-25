namespace Medicar_API.Domain.Entities;

public class Schedule
{
    public int ScheduleId { get; set; }
    public DateOnly Date { get; set; }
    public bool Available { get; set; }
    public int DoctorId { get; set; }
    public virtual Doctor Doctor { get; set; }
    public virtual ICollection<Slot> Slots { get; set; }
}
