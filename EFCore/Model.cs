using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

[Table("Blogs")]
public class Blog
{
    [PrimaryKey]
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
        DbPath = System.IO.Path.Join(path, "blogging.db");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        options.UseSqlite($"Data Source={DbPath}");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>()
            .Property(b => b.Url)
            .IsRequired();

        modelBuilder.Entity<Blog>().HasData(
            new Blog { BlogId = 1, Url = "https://test.com/kfdslfjdsklf" },
            new Blog { BlogId = 2, Url = "https://sss.io/dsjfdksafjdsaf" });
    }
}
