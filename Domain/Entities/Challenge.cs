namespace Domain.Entities;

public class Challenge
{
    public int ChallengeId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    //Reference props
    public virtual List<Group> Groups { get; set; }
}
