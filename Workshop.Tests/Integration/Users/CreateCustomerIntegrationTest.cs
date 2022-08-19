using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using Users.Application.Features;

namespace Workshop.Tests.Integration.Users;

public class CreateCustomerIntegrationTest
{
    [Test]
    public async Task Test_CreateCustomerShouldReturnUserId()
    {
        var testServer = new IntegrationTestServer();

        var createUserCommand = new CreateCustomer.Command()
        {
            Email = "testuser@gmail.com",
            Name = "Lazaro Junior",
            Password = "Pass0wor0d@@"
        };

        var response = await testServer.Client.PostAsJsonAsync("/api/customer", createUserCommand);
        var serializedResponseContent = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<CreateCustomer.Result>(serializedResponseContent);
        
        Assert.True(response.IsSuccessStatusCode);
        Assert.NotNull(result);
        Assert.NotZero(result.UserId);
    }
}