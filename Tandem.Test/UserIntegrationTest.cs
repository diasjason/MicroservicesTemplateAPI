using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Tandem.Application.User.Queries;
using Tandem.Domain.Entities;
using Xunit;

namespace Tandem.Test
{
    public class UserIntegrationTest
    {
        private readonly HttpClient _client;
        public UserIntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            _client = appFactory.CreateClient();
        }

        #region Get Test

        [Fact]
        public async Task Get_WithoutParameters_ReturnsAllUserList()
        {
            //Act
            var response = await _client.GetAsync("api/user");
            var usersList = await response.Content.ReadAsAsync<List<UserVm>>();

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            usersList.Should().NotBeEmpty();
        }

        [Theory]
        [InlineData("mat@awesomedomain.com")]
        [InlineData("madeup@gmail.com")]
        public async Task Get_ByEmail_ReturnsCorrectUser(string email)
        {
            //Act
            var response = await _client.GetAsync($"api/user/{email}");
            var user = await response.Content.ReadAsAsync<UserVm>();

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            user.Should().NotBeNull();
            user.Name.Should().NotBeEmpty();
            user.EmailAddress.Should().Be(email);
        }

        [Fact]
        public async Task Get_ByEmail_ReturnsNewCreatedUser()
        {
            //Arrange
            var email = "created@user.com";
            var newUser = new User { FirstName = "First", LastName = "Last", MiddelName = "Middle", PhoneNumber = "111-222-3333", EmailAddress = email };
            await _client.PostAsJsonAsync("api/user", newUser);

            //Act
            var response = await _client.GetAsync($"api/user/{email}");
            var user = await response.Content.ReadAsAsync<UserVm>();

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            user.Should().NotBeNull();
            user.Name.Should().Be($"{newUser.FirstName} {newUser.MiddelName} {newUser.LastName}");
            user.EmailAddress.Should().Be(newUser.EmailAddress);
        }

        [Fact]
        public async Task Get_ByEmail_ReturnsNotFound()
        {
            //Arrange
            var email = "never@used.email";

            //Act
            var response = await _client.GetAsync($"api/user/{email}");
            var user = await response.Content.ReadAsAsync<UserVm>();

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
        #endregion

        #region PostTest
        [Fact]
        public async Task Post_ValidRequest_SuccessfullyCreatesUser()
        {
            //Arrange
            var user = new User { FirstName = "First", LastName = "Last", MiddelName = "Middle", PhoneNumber = "111-222-3333", EmailAddress = "firstemail@test.com" };

            //Act
            var response = await _client.PostAsJsonAsync("api/user", user);
            var result = await response.Content.ReadAsAsync<bool>();

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().Be(true);
        }

        [Fact]
        public async Task Post_InValidRequest_ReturnsFailure()
        {
            //Arrange
            var user = new User { FirstName = "First", LastName = "Last", MiddelName = "Middle", PhoneNumber = "111-222-3333", EmailAddress = "InvalidEmail" };

            //Act
            var response = await _client.PostAsJsonAsync("api/user", user);
            var result = await response.Content.ReadAsAsync<object>();

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            result.ToString().Should().Contain("One or more validation failures have occurred.");
        }
        #endregion
    }
}