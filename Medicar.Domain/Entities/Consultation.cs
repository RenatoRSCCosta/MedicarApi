namespace Medicar_API.Domain.Entities;

public class Consultation
{
    public int ConsultationId { get; set; }
    public int ScheduleId { get; set; }
    public virtual Schedule Schedule { get; set; }
    public int SlotId { get; set; }
    public virtual Slot Slot { get; set; }
    public DateTime AppointmentDate { get; set; }
}
