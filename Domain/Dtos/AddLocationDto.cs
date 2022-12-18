using Domain.Entities;

namespace Domain.Dtos;

public class AddLocationDto
{
    public int LocationId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}