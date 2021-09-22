using Application.Common.Exceptions;
using Application.Users.Commands.CreateUser;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Application.IntegrationTests.Users.Commands
{
    using static Testing;

    public class CreateUserTests : TestBase
    {
        [Test]
        public void Should_Require_Minimum_UserName()
        {
            var command = new CreateUserCommand { UserName = "Fo", Password = "password" };

            FluentActions.Invoking(()=> SendAsync(command)).Should().ThrowAsync<ValidationException>();
        }

        [Test]
        public void Should_Require_Minimum_Password()
        {
            var command = new CreateUserCommand { UserName = "Foo", Password = "pas" };

            FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<ValidationException>();
        }

        [Test]
        public async Task Should_Create_New_User()
        {
            var userId = await RunAsDefaultUserAsync();
            userId.Should().NotBeNull();

        }
    }
}
