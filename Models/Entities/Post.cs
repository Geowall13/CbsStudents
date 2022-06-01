using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CbsStudents.Models.Entities;

public class Post{


    public int PostId { get; set; }

    [Required(ErrorMessage = "Please fill out a title")]
    [MinLength(3, ErrorMessage = "Title should be a minimum of 3 letters")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "A post need some text")]
    [MinLength(10, ErrorMessage = "A post should be a minimum 10 letters long")]
    public string? Text { get; set; }

    public DateTime Created { get; set; }

    public PostStatus Status { get; set; }

    public List<Comment>? Comments { get; set; }

    public string? UserId { get; set; }

    public IdentityUser? User { get; set; }

}