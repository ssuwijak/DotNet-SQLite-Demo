using SQLite;

[Table("Blogs")]
public class Blog
{
    [PrimaryKey]
    public int BlogId { get; set; }
    public string Url { get; set; }
}