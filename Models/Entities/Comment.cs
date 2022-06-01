using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CbsStudents.Models.Entities;


public class Comment{


    public int CommentId { get; set; }

    [Required(ErrorMessage = "A comment need some text")]
    public string? Text { get; set; }

    [DataType(DataType.Date)]
    public DateTime Created { get; set; }

    public int PostId {get; set;}
    public Post? Post {get; set;}

    public string? UserId { get; set; }

    public IdentityUser? User { get; set; }

}