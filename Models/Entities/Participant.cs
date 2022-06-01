namespace CbsStudents.Models.Entities;

public class Participant{

    public int ParticipantId { get; set; }

    public string Name { get; set; }

    public Event? Event { get; set; }

    public int EventId { get; set; }
}