using Microsoft.EntityFrameworkCore;

await using var db = new BloggingContext();
await db.Database.EnsureCreatedAsync();

Console.WriteLine($"Database path: {db.DbPath}");

Console.WriteLine("Query for blogs");

var results = from blog in db.Blogs
              where blog.BlogId == 1
              select blog;

await foreach (var s in results.AsAsyncEnumerable())
{
    Console.WriteLine($"Blog id: {s.BlogId}\tBlog url: {s.Url}");
}