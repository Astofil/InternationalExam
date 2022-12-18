using Domain.Entities;

namespace Domain.Dtos;

public class GetGroupDto
{
    public int GroupId { get; set; }
    public string GroupNick { get; set; }
    public int ChallengeId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool NeedMember { get; set; }
    public string TeamSlogan{ get; set; } //////TeanSloGan
    public DateTime CreatedAt { get; set; }

}

