using Dapper;
using Microsoft.Data.Sqlite;

string dbPath = "blogging.db";

Console.WriteLine($"Database path: {dbPath}");


Console.WriteLine("Query for blogs");

await using var connection = new SqliteConnection($"Data Source={dbPath}");

var sql = "SELECT * FROM Blogs WHERE BlogId = 1";

var results = await connection.QueryAsync<Blog>(sql);

foreach (var s in results)
{
    Console.WriteLine($"Blog id: {s.BlogId}\tBlog url: {s.Url}");
}