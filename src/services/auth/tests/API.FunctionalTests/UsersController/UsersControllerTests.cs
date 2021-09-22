using API.FunctionalTests;
using Application.Users;
using auth;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Functional.Tests.UsersController
{
    public class UsersControllerTests
    {
        private CustomWebApplicationFactory<Startup> webApp;

        [SetUp]
        public void Setup()
        {

            webApp = new CustomWebApplicationFactory<Startup>();
        }

        [Test]
        public async Task Should_Return_Users()
        {
            IEnumerable<AppUserDto> users = null;

            using (var httpClient = webApp.CreateClient())
            {
                var response = await httpClient.GetAsync("/users/");
                users = await response.Content.ReadFromJsonAsync<IEnumerable<AppUserDto>>();
            }

            foreach (var user in users)
            {
                Console.WriteLine(user.UserName);
            }

            users.Count().Should().Be(4);
            users.ElementAt(0).UserName.Should().Be("admin");
            users.ElementAt(1).UserName.Should().Be("foouser");
            users.ElementAt(2).UserName.Should().Be("baruser");
            users.ElementAt(3).UserName.Should().Be("hellouser");
        }
    }
}