using SQLite;

var folder = Environment.SpecialFolder.LocalApplicationData;
var path = Environment.GetFolderPath(folder);
var dbPath = Path.Join(path, "blogging.db");

var db = new SQLiteAsyncConnection(dbPath);

Console.WriteLine($"Database path: {dbPath}");

Console.WriteLine("Query for blogs");

var results = from blog in db.Table<Blog>()
              where blog.BlogId == 1
              select blog;

foreach (var s in await results.ToListAsync())
{
    Console.WriteLine($"Blog id: {s.BlogId}\tBlog url: {s.Url}");
}