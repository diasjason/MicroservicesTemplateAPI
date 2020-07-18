using FluentAssertions;
using MicroservicesTemplateAPI.Application.Contact.Queries;
using MicroservicesTemplateAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace MicroservicesTemplateAPI.Test
{
    public class ContactIntegrationTest
    {
        public readonly HttpClient _client;
        public ContactIntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            _client = appFactory.CreateClient();
        }
        #region Get Test

        [Fact]
        public async Task Get_WithoutParameters_ReturnsAllContactsList()
        {
            //Act
            var response = await _client.GetAsync("api/contact");
            var contactsList = await response.Content.ReadAsAsync<List<ContactVm>>();

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            contactsList.Should().NotBeEmpty();
        }

        [Theory]
        [InlineData("test@used.email")]
        [InlineData("created@contact.com")]
        public async Task Get_ByEmail_ReturnsCorrectContact(string email)
        {
            //Act
            var response = await _client.GetAsync($"api/contact/{email}");
            var contact = await response.Content.ReadAsAsync<ContactVm>();

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            contact.Should().NotBeNull();
            contact.Name.Should().NotBeEmpty();
            contact.Email.Should().Be(email);
        }

        [Fact]
        public async Task Get_ByEmail_ReturnsNewCreatedContact()
        {
            //Arrange
            var email = "created@contact.com";
            var newContact = new Contact
            {
                Name = "Name",
                Company = "Microsoft",
                StreetAddress = "Middle",
                City = "Mumbai",
                State = "MH",
                Phone = "111-222-3333",
                Email = email,
                Type = "dev",
                AssignedTo = "PT"
            };
            await _client.PostAsJsonAsync("api/contact", newContact);

            //Act
            var response = await _client.GetAsync($"api/contact/{email}");
            var contact = await response.Content.ReadAsAsync<ContactVm>();

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            contact.Should().NotBeNull();
            contact.Name.Should().Be(newContact.Name);
            contact.Email.Should().Be(newContact.Email);
        }

        [Fact]
        public async Task Get_ByEmail_ReturnsNotFound()
        {
            //Arrange
            var email = "never@used.email";

            //Act
            var response = await _client.GetAsync($"api/contact/{email}");
            var contact = await response.Content.ReadAsAsync<ContactVm>();

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
        #endregion

        #region PostTest
        [Fact]
        public async Task Post_ValidRequest_SuccessfullyCreatesContact()
        {
            //Arrange
            var contact = new Contact
            {
                Name = "Name",
                Company = "Microsoft",
                StreetAddress = "Middle",
                City = "Mumbai",
                State = "MH",
                Phone = "111-222-3333",
                Email = "test@used.email",
                Type = "dev",
                AssignedTo = "PT"
            };

            //Act
            var response = await _client.PostAsJsonAsync("api/contact", contact);
            var result = await response.Content.ReadAsAsync<bool>();

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().Be(true);
        }

        [Fact]
        public async Task Post_InValidRequest_ReturnsFailure()
        {
            //Arrange
            var contact = new Contact
            {
                Name = "Name",
                Company = "Microsoft",
                StreetAddress = "Middle",
                City = "Mumbai",
                State = "MH",
                Phone = "111-222-3333",
                Email = "tesemail",
                Type = "dev",
                AssignedTo = "PT"
            };
            //Act
            var response = await _client.PostAsJsonAsync("api/contact", contact);
            var result = await response.Content.ReadAsAsync<object>();

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            result.ToString().Should().Contain("One or more validation failures have occurred.");
        }
        #endregion
    }
}
