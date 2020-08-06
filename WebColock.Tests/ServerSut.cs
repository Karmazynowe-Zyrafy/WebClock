using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using WebClock;

namespace WebColock.Tests
{
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
            }).CreateClient();
        }

        public async Task<T> DoGet<T>(string path)
        {
            var result = await Client.GetAsync(path);
            var content = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
