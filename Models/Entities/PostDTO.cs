namespace CbsStudents.Models.Entities;

public class PostDTO{


    public int PostId { get; set; }

    public string? Title { get; set; }

    public string? Text { get; set; }

    public DateTime Created { get; set; }

    public PostStatus Status { get; set; }

    public string? UserId { get; set; }
}