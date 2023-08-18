namespace Medicar_API.Domain.Entities;

public class Doctor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Crm { get; set; }
    public string Email { get; set; }
    public Specialty Specialty { get; set; }
}