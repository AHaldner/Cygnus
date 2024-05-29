using MySql.Data.MySqlClient;
using DotNetEnv;

namespace Cygnus.Utils
{
    public static class FetchDatabase
    {
        private static readonly string connectionString;

        static FetchDatabase()
        {
            Env.Load();

            var server = Environment.GetEnvironmentVariable("DB_SERVER");
            var user = Environment.GetEnvironmentVariable("DB_USER");
            var database = Environment.GetEnvironmentVariable("DB_NAME");
            var port = Environment.GetEnvironmentVariable("DB_PORT");
            var password = Environment.GetEnvironmentVariable("DB_PASSWORD");

            connectionString = $"server={server};user={user};database={database};port={port};password={password}";
        }

        public static async Task<List<string[]>> FetchDataAsync(string tableName)
        {
            var data = new List<string[]>();

            try
            {
                using var connection = new MySqlConnection(connectionString);
                await connection.OpenAsync();

                using var command = new MySqlCommand($"SELECT * FROM `{tableName}`", connection);
                using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    var contents = new string[3]
                    {
                        reader.GetString(1),
                        reader.GetDateTime(2).ToString("dd.MM.yyyy HH:mm:ss"),
                        reader.GetString(3)
                    };

                    data.Add(contents);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error fetching data: {ex.Message}");
            }

            return data;
        }

        public static async Task<List<string>> FetchSpecificDataAsync(string tableName, int packageID)
        {
            var data = new List<string>();

            try
            {
                using var connection = new MySqlConnection(connectionString);
                await connection.OpenAsync();

                using var command = new MySqlCommand($"SELECT * FROM `{tableName}` WHERE packageID = @packageID", connection);
                command.Parameters.AddWithValue("@packageID", packageID);
                using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    data.Add(reader.GetString(0));
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error fetching specific data: {ex.Message}");
            }

            return data;
        }
    }
}