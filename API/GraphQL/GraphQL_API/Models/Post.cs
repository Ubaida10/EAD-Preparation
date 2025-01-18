namespace GraphQL_API.Models;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int AuthorId { get; set; }   // Foreign key for Author
    public Author Author { get; set; } // Navigation property
    public List<Comment> Comments { get; set; } = new();
}