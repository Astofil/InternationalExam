using Domain.Entities;

public class AddGroupDto
{
    public int GroupId { get; set; }
    public string GroupNick { get; set; }
    public int ChallengeId { get; set; }
    public bool NeedMember { get; set; }
    public string TeamSlogan { get; set; } //////TeanSloGan
    public DateTime CreatedAt { get; set; }
}