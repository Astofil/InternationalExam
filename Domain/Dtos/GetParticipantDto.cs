using Domain.Entities;

namespace Domain.Dtos;

public class GetParticipantDto
{
    public int ParticipantId { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; }

    //Groups props
    public int GroupId { get; set; }
    public string GroupNick { get; set; }
    public int ChallengedId { get; set; }
    public bool NeedMember { get; set; }
    public string TeamSlogan { get; set; }////////TeanSlogan
    public DateTime GroupCreatedAt { get; set; }

    //Locations props
    public int LocationId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

}
//GetParticipantDto