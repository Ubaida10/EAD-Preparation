using GraphQL_API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();
    

// Configure EF Core with SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); 


var app = builder.Build();

app.MapGet("/", ()=>"Navigate to: http://localhost:5001/graphql");

// Use GraphQL
app.MapGraphQL("/graphql");

app.Run();
