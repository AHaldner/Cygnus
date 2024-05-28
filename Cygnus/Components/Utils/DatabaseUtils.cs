using MySql.Data.MySqlClient;
using DotNetEnv;

namespace Cygnus.Utils
{
    public static class FetchDatabase
    {
        public static async Task<List<string>> FetchData(string tableName)
        {
            Env.Load();

            var server = Environment.GetEnvironmentVariable("DB_SERVER");
            var user = Environment.GetEnvironmentVariable("DB_USER");
            var database = Environment.GetEnvironmentVariable("DB_NAME");
            var port = Environment.GetEnvironmentVariable("DB_PORT");
            var password = Environment.GetEnvironmentVariable("DB_PASSWORD");

            var connectionString =
            $"server={server};user={user};database={database};port={port};password={password}";
            using var connection = new MySqlConnection(connectionString);
            await connection.OpenAsync();

            using var command = new MySqlCommand($"SELECT * FROM {tableName}", connection);
            using var reader = await command.ExecuteReaderAsync();

            var data = new List<string>();
            while (await reader.ReadAsync())
            {
                data.Add(reader.GetString(3));
            }

            return data;
        }
    }
}