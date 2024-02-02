namespace Medicar_API.Domain.Entities;

public class Schedule
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public bool Available { get; set; }
    public int DoctorId { get; set; }
    public Doctor? Doctor { get; set; }
    public ICollection<Slot>? Slots { get; set; }
    public ICollection<Consultation>? Consultations { get; set; }
}
