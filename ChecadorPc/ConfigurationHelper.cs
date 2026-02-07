using Microsoft.Extensions.Configuration;
using System.IO;

namespace ChecadorPc
{
    public static class ConfigurationHelper
    {
        private static IConfiguration _configuration;

        public static IConfiguration Configuration
        {
            get
            {
                if (_configuration == null)
                {
                    LoadConfiguration();
                }
                return _configuration;
            }
        }

        private static void LoadConfiguration()
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            _configuration = configBuilder.Build();
        }

        public static string GetConnectionString(string name = "DefaultConnection")
        {
            return Configuration.GetConnectionString(name);
        }
    }
}