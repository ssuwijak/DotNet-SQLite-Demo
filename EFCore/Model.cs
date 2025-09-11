using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Blogs")]
public class Blog
{
    public int BlogId { get; set; }
    public string Url { get; set; } = string.Empty;
}
public class BloggingContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public string DbPath { get; }
    public BloggingContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "blogging.db");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
          => options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Blog>()
        //    .Property(b => b.Url)
        //    .IsRequired();

        modelBuilder.Entity<Blog>().HasData(
            new Blog { BlogId = 1, Url = "https://test.com/kfdslfjdsklf" },
            new Blog { BlogId = 2, Url = "https://sss.io/dsjfdksafjdsaf" });
    }
}
