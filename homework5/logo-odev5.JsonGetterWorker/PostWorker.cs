using logo_odev5.Business.Abstracts;
using logo_odev5.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace logo_odev5.JsonGetterWorker
{
    public class PostWorker : BackgroundService
    {
        private readonly IPostQueue<Post> queue;
        private readonly IServiceScopeFactory serviceFactory;
        private readonly ILogger<PostWorker> logger;
        private HttpClient httpClient;

        public PostWorker(IPostQueue<Post> queue, IServiceScopeFactory serviceFactory, ILogger<PostWorker> logger)
        {
            this.queue = queue;
            this.serviceFactory = serviceFactory;
            this.logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            httpClient = new HttpClient();
            return base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var request = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");

                if (request.IsSuccessStatusCode)
                {
                    var response = await request.Content.ReadAsStringAsync();

                    List<Post> posts = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Post>>(response);

                    foreach (var post in posts)
                    {
                        queue.Enqueue(post);
                        logger.LogInformation("Enqueued post id:{}", post.Id);
                        await Task.Delay(15000);
                        //new post will only be queued every 15 seconds because we are inserting to db every 60 seconds
                    }
                }
                else
                {
                    logger.LogError("An error occured while getting data from api");
                }
                await Task.Delay(5400000, cancellationToken);
                // jsonplaceholder api has 100 lines of post. Only one post will be inserted into db per minute so we don't need to choke our queue.
            }
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogCritical("The {Type} is stopping due to a host shutdown, queued items might not be processed anymore.", nameof(PostWorker));
            base.Dispose();
            return base.StopAsync(cancellationToken);
        }
        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
