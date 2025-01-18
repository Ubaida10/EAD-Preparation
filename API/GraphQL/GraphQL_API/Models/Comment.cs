namespace GraphQL_API.Models;

public class Comment
{
    public int Id { get; set; }
    public string Text { get; set; }
    public int PostId { get; set; } // Foreign key for Post
    public Post Post { get; set; } // Navigation property
}