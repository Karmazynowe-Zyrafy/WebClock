using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<string> DoPost<T>(string path, T content) //Może będzie Task<T> 
        {
            var jsonString = JsonConvert.SerializeObject(content);
            var stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var result = await Client.PostAsync(path, stringContent);
            try
            {
                result.StatusCode.Should().Be(200);
                return await result.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
