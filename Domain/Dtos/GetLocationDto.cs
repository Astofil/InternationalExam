using Domain.Entities;

namespace Domain.Dtos;

public class GetLocationDto
{
    public int LocationId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}