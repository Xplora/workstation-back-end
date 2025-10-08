namespace TripMatch.Xplore.Platform.DAP.Domain.Models.Entities;

public class Category 
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Experience> Experiences { get; set; } = new();
}