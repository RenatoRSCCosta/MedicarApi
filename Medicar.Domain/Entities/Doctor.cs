namespace Medicar_API.Domain.Entities;

public class Doctor
{
    public int DoctorId { get; set; }
    public string Name { get; set; }
    public string Crm { get; set; }
    public string Email { get; set; }
    public int SpecialtyId { get; set; }
    public virtual Specialty Specialty { get; set; }
}