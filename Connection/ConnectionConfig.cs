using Microsoft.Extensions.Configuration;
using System.IO;

namespace Connection
{
    public static class ConnectionConfig
    {
        public static string GetDefaultConnectionString() => GetConnectionString("DefaultConnection");

        private static string GetConnectionString(string connectionName)
        {
            return CreateConfiguration().GetConnectionString(connectionName);
        }

        private static IConfigurationRoot CreateConfiguration()
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            string[] currentDirectorySplit = Directory.GetCurrentDirectory().Split("EntityFrameworkCore");
            string configFilePath = $"{currentDirectorySplit[0]}EntityFrameworkCore\\Connection";
            builder.SetBasePath(configFilePath);
            builder.AddJsonFile("appsettings.json");
            return builder.Build();
        }
    }
}
