using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_10_2.Application;

namespace Week_10_2.Infrastructure.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private static ConfigurationService instance;
        private readonly IConfiguration _configuration;

        public static ConfigurationService GetInstance()
        {
            if (instance is null)
                instance = new ConfigurationService();
            return instance;

        }

        public ConfigurationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetValue(string key)
        {

            return _configuration[key];

        }

        ConfigurationService()
        {
            Console.WriteLine("Instance Created!");
        }
    }
}
