using Domain.Dtos;

namespace Domain.Entities;

public class GetChallengeDto
{
    public int ChallengeId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}