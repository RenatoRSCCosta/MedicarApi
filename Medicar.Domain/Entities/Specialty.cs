namespace Medicar_API.Domain.Entities;

public class Specialty
{
    public int SpecialtyId { get; set; }
    public string Name { get; set; }
    public Doctor Doctor { get; set; }
}

