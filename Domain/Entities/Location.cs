namespace Domain.Entities;

public class Location
{
    public int LocationId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    //----------Referenced props------------
    public virtual List<Participant> Participants { get; set; }
}
