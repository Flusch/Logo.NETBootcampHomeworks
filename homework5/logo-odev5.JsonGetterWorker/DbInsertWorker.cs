using logo_odev5.Business.Concretes;
using logo_odev5.Business.Abstracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using logo_odev5.Domain.Entities;

namespace logo_odev5.JsonGetterWorker
{
    public class DbInsertWorker : BackgroundService
    {
        private readonly IPostQueue<Post> queue;
        private readonly IServiceScopeFactory serviceFactory;
        private readonly ILogger<DbInsertWorker> logger;

        public DbInsertWorker(IPostQueue<Post> queue, IServiceScopeFactory serviceFactory, ILogger<DbInsertWorker> logger)
        {
            this.queue = queue;
            this.serviceFactory = serviceFactory;
            this.logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            logger.LogInformation("{Type} is now running in the background.", nameof(DbInsertWorker));
            await BackgroundProcessing(stoppingToken);
        }
        private async Task BackgroundProcessing(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await Task.Delay(60000, stoppingToken);
                    var post = queue.Dequeue();
                    if (post == null) continue;

                    logger.LogInformation("Inserting post id:{} to db.", post.Id);
                    using (var scope = serviceFactory.CreateScope())
                    {
                        var postService = scope.ServiceProvider.GetService<IPostService>();
                        await postService.AddPost(post, stoppingToken);
                    }
                }
                catch (Exception ex)
                {
                    logger.LogError("An Error occured while processing posts. Exception: ", ex);
                }
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
