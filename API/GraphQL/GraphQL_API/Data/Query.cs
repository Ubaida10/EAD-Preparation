using GraphQL_API.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_API.Data;

public class Query
{
    public IQueryable<Post> GetPosts([Service] AppDbContext dbContext) =>
        dbContext.Posts.Include(p => p.Author).Include(p => p.Comments);

    public IQueryable<Author> GetAuthors([Service] AppDbContext dbContext) =>
        dbContext.Authors.Include(a => a.Posts);

    public IQueryable<Comment> GetComments([Service] AppDbContext dbContext) =>
        dbContext.Comments.Include(c => c.Post);
    
    // Query to get a specific post by Id
    public Post GetPostById(int id, [Service] AppDbContext dbContext) =>
        dbContext.Posts.Include(p => p.Author).Include(p => p.Comments).FirstOrDefault(p => p.Id == id);
}