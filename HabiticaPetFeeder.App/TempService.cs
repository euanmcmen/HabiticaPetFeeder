using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.App
{
    public class TempService : ITempService
    {
        private readonly ILogger<TempService> logger;
        private readonly IConfiguration configuration;

        public TempService(ILoggerFactory loggerFactory, IConfiguration configuration)
        {
            logger = loggerFactory.CreateLogger<TempService>();
            this.configuration = configuration;
        }

        public void DoAThing()
        {
            logger.LogInformation("Doing thing...");
        }

        public void DoNextThing()
        {
            logger.LogInformation("Doing the next thing...");
        }

        public void DoWithString()
        {
            logger.LogInformation($"Doing with string: {configuration.GetValue<string>("Temp")}");
        }
    }
}
