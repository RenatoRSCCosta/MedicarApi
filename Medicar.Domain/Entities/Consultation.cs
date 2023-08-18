namespace Medicar_API.Domain.Entities;

public class Consultation
{
    public int Id { get; set; }
    public int ScheduleId { get; set; }
    public int SlotId { get; set; }
    public DateTime AppointmentDate { get; set; }
}
