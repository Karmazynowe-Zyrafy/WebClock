using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebClock;
using WebClock.Models;
using WebClock.Models.MemoryRepository;

namespace WebColock.Tests
{
    public class ServerSutStartup : Startup
    {
        public ServerSutStartup(IConfiguration configuration) : base(configuration)
        {
        }
        protected override void SetupRepository(IServiceCollection services)
        {
            services.AddSingleton(typeof(IRepository), typeof(MemoryRepository));
        }
    }
}