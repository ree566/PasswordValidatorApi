using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using PasswordValidatorApi;
using PasswordValidatorApi.Models;
using Xunit;

namespace PasswordValidatorApiTest
{
    public class PasswordValidatorIntegrationTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public PasswordValidatorIntegrationTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddSingleton<IPasswordValidator>(new PasswordValidator() {
                        RequiredDigit = true,
                        RequiredLengthMin = 1,
                        RequiredLengthMax = 10,
                        RequiredNonLetterOrDigit = false,
                        RequiredLowercase = true,
                        RequiredUppercase = false
                    });
                });
            });
        }

        [Theory]
        [InlineData("ABCDE")]
        [InlineData("12345")]
        [InlineData("ABC123")]
        public async Task ValidatePassword(string value)
        {
            var client = _factory.CreateClient();
            var payload = new
            {
                password = value
            };
            var httpContent = new StringContent(JsonSerializer.Serialize(payload));
            var response = await client.PostAsync("/api/passwordValidate", httpContent);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var body = await response.Content.ReadAsStringAsync();
            var created = JsonSerializer.Deserialize<JsonElement>(body);
        }
    }
}
