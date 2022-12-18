namespace Domain.Entities;

public class Group
{
    public int GroupId { get; set; }
    public string GroupNick { get; set; }
    public int ChallengeId { get; set; }
    public Challenge Challenge { get; set; }//
    public bool NeedMember { get; set; }
    public string TeamSloGan { get; set; } //////TeanSloGan
    public DateTime CreatedAt { get; set; }

    //--------Refereced props-----------
    public virtual List<Participant> Participants { get; set; }
}
