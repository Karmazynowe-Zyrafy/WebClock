using System;
using System.Net.Http;
using Newtonsoft.Json;
using WebClock;
using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace WebColock.Tests.IntegrationTest
{
    public class IntegrationClockControllerTests
    {
        [Fact]
        public async void TestPostRegistration()
        {
            var server =new ServerSut();
            var jsonObject = new JObject();
            jsonObject.Add("id", 1);
            var stringContent = new StringContent(jsonObject.ToString());
            var result = await server.DoPost("/clock",stringContent);
            result.Should().BeOfType<OkResult>();
        }

    }
}