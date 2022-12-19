using Microsoft.AspNetCore.Mvc.Testing;
using PasswordValidatorApi;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using PasswordValidatorApi.Models;
using PasswordValidatorApi.Models.ValidatorRules;
using Microsoft.Extensions.DependencyInjection;

namespace PasswordValidatorApiTest.IntegrationTests
{
    public class PasswordValidateControllerTest
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public PasswordValidateControllerTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddSingleton<IPasswordValidator>(new PasswordValidator(
                        new ValidatorRuleServiceImpl()
                        {
                            Rules =
                            {
                                new CharacterLengthFilterRule(1, 15),
                                new LowerCaseAndDigitsOnlyRule(),
                                new NotContainAdjacentSameSequenceRule()
                            }
                        }
                        ));
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
