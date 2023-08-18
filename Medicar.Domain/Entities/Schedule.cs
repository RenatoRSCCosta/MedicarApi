namespace Medicar_API.Domain.Entities;

public class Schedule
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public bool Available { get; set; }
    public Doctor Doctor { get; set; }
}
