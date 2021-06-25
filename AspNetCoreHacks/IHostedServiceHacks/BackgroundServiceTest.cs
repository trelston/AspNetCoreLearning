using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace IHostedServiceHacks
{
    public class BackgroundServiceTest : BackgroundService
    {
        private readonly ILogger<BackgroundServiceTest> _logger;

        public BackgroundServiceTest(ILogger<BackgroundServiceTest> logger)
        {
            _logger = logger;
        }
        
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(2000);
                _logger.LogInformation($"Logged time {DateTime.Now.Ticks}");
            }
        }
    }
}