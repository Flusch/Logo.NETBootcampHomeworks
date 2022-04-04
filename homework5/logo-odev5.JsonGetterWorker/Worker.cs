using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace logo_odev5.JsonGetterWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private HttpClient httpClient;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }


        public override Task StartAsync(CancellationToken cancellationToken)
        {
            httpClient = new HttpClient();
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            httpClient.Dispose();
            return base.StopAsync(cancellationToken);
        }

        public override void Dispose()
        {
            base.Dispose();
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var request = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");
                if (request.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Json Place Holder Data {0}", request.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    _logger.LogError("Error Status Code ", request.StatusCode);
                }

                await Task.Delay(10000, stoppingToken);
            }
        }
    }
}
