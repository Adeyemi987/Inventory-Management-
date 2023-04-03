using Microsoft.Extensions.Configuration;
using Npgsql;
using System;

namespace InventoryBeginners
{
    public static class ConnectionHelper
    {
        public static string GetConnectionString(IConfiguration configuration)
        {       
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
            return string.IsNullOrEmpty(databaseUrl) ? connectionString : BuildConnectionString(databaseUrl);

        }

        //build connectionstring from the environment, Heroku or Railway
        private static string BuildConnectionString(string databaseUrl) 
        {
            var databaseUri = new Uri(databaseUrl);
            var userInfo = databaseUri.UserInfo.Split(':');
            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = databaseUri.Host,
                Port = databaseUri.Port,
                Username = userInfo[0],
                Password = userInfo[1],
                Database = databaseUri.LocalPath.TrimStart('/'),
                SslMode = SslMode.Require,
                TrustServerCertificate = true
            };
            return builder.ToString();

        }

    }
}
