using Microsoft.Data.Sqlite;

string projPath = "";
string dbPath = Path.Combine(projPath, "blogging.db");
Console.WriteLine($"Database path: {dbPath}");

Console.WriteLine("Querying for blogs");

await using var conn = new SqliteConnection($"Data Source={dbPath}");
await conn.OpenAsync();
await using var cmd = new SqliteCommand("SELECT Name FROM Blogs", conn);
await using var reader = await cmd.ExecuteReaderAsync();


while (await reader.ReadAsync())
{
    Console.WriteLine($"\nBlog id: " + reader["BlogId"]);
    Console.WriteLine($"\tBlog url: " + reader["Url"]);
}
