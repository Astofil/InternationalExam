namespace Domain.Entities;

public class Participant
{
    public int Participantid { get; set; }
    public string Fullname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; }
    //---------Referenced props---------------
    public int GroupId { get; set; }
    public Group Group { get; set; }
    public int LocationId { get; set; }
    public Location Location { get; set; }
}
