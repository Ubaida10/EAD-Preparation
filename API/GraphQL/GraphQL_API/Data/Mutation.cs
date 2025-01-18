using GraphQL_API.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_API.Data;

public class Mutation
{
    public record AuthorInput(string Name);
    public record PostInput(string Title, string Content, int AuthorId);
    public record CommentInput(string Text, int PostId);

    public async Task<Post> AddPost(PostInput post, [Service] AppDbContext dbContext)
    {
        var newPost = new Post
        {
            Title = post.Title,
            Content = post.Content,
            AuthorId = post.AuthorId
        };

        dbContext.Add(newPost);
        await dbContext.SaveChangesAsync();

        return newPost;
    }

    public async Task<Comment> AddComment(CommentInput comment, [Service] AppDbContext dbContext)
    {
        var newComment = new Comment
        {
            Text = comment.Text,
            PostId = comment.PostId
        };

        dbContext.Add(newComment);
        await dbContext.SaveChangesAsync();

        return newComment;
    }

    public async Task<Author> AddAuthor(AuthorInput author, [Service] AppDbContext dbContext)
    {
        var newAuthor = new Author
        {
            Name = author.Name
        };

        dbContext.Add(newAuthor);
        await dbContext.SaveChangesAsync();

        return newAuthor;
    }

    public async Task<Post> DeletePost(int id, [Service] AppDbContext dbContext)
    {
        var post = dbContext.Posts.FirstOrDefault(p => p.Id == id);

        if (post == null)
        {
            throw new Exception("Post NOT found");
        }

        dbContext.Remove(post);
        await dbContext.SaveChangesAsync();
        return post;
    }

    public async Task<Post> UpdatePost(int id, PostInput inputPost, [Service] AppDbContext dbContext)
    {
        var post = dbContext.Posts.FirstOrDefault(p => p.Id == id);
        if (post == null)
        {
            throw new Exception("Post NOT found");
        }
        post.Title = inputPost.Title;
        post.Content = inputPost.Content;
        post.AuthorId = inputPost.AuthorId;
        await dbContext.SaveChangesAsync();
        
        return dbContext.Posts.Include(p => p.Author).Include(p => p.Comments).FirstOrDefault(p => p.Id == id);
    }
    
}