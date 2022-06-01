using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CbsStudents.Models.Entities;

public class Event{

    public int EventId { get; set; }

    [Required(ErrorMessage = "Please fill out a title")]
    [MinLength(3, ErrorMessage = "Title should be a minimum of 3 letters")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "An event need a description")]
    [MinLength(10, ErrorMessage = "A description should be a minimum 10 letters long")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "An event needs a start time")]
    public DateTime StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    [Required(ErrorMessage = "An event must have a location")]
    public string Location { get; set; }

    public string? UserId { get; set; }

    public IdentityUser? User { get; set; }

    public List<Participant>? Participants { get; set; }
}