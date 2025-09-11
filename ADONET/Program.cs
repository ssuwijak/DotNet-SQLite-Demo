using Microsoft.Data.Sqlite;

var folder = Environment.SpecialFolder.LocalApplicationData;
var path = Environment.GetFolderPath(folder);
var dbPath = Path.Join(path, "blogging.db");

Console.WriteLine($"Database path: {dbPath}");

Console.WriteLine("Querying for blogs");

await using var conn = new SqliteConnection($"Data Source={dbPath}");
await conn.OpenAsync();
await using var cmd = new SqliteCommand("SELECT * FROM Blogs where BlogId = 1", conn);
await using var reader = await cmd.ExecuteReaderAsync();

while (await reader.ReadAsync())
{
    Console.Write($"\nBlog id: " + reader["BlogId"]);
    Console.WriteLine($"\tBlog url: " + reader["Url"]);
}
