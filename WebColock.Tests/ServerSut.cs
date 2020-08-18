using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using WebClock;
using WebClock.Models;
using WebClock.Models.MemoryRepository;

namespace WebColock.Tests
{
    //public class ServerSutStartup : Startup
    //{
    //    //public ServerSutStartup(IConfiguration configuration) : base(configuration)
    //    //{
    //    //}
    //    public ServerSutStartup(IConfiguration configuration) : base(configuration)
    //    {
    //    }
    //    protected override void SetupRepository(IServiceCollection services)
    //    {
    //        services.AddSingleton(typeof(IRepository), typeof(MemoryRepository));
    //    }
    //}
    public class ServerSut
    {
        public HttpClient Client { get; }

        public ServerSut()
        {
            var webApplication = new WebApplicationFactory<Startup>();
            Client = webApplication.WithWebHostBuilder(builder =>
            {
                builder.UseEnvironment("Debug");
                builder.UseStartup<Startup>();
                builder.ConfigureTestServices(services =>
                {
                    services.AddControllersWithViews()
                        .AddApplicationPart(typeof(Startup).Assembly);
                    services.AddSingleton(typeof(IRepository), typeof(MemoryRepository));
                });
            }).CreateClient();
        }

        public async Task<T> DoGet<T>(string path)
        {
            var result = await Client.GetAsync(path);
            var content = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }

        public async Task<T> DoPost<T>(string path, object content)
        {
            var jsonString = JsonConvert.SerializeObject(content);
            var stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var result = await Client.PostAsync(path, stringContent);

            result.StatusCode.Should().Be(200);

            var resultContent = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(resultContent);
        }
    }
}
