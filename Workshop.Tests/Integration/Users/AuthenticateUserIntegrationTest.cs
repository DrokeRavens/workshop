using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using Users.Contracts;

namespace Workshop.Tests.Integration.Users;

public class AuthenticateUserIntegrationTest
{
    [Test]
    public async Task Test_AuthenticationShouldReturnTokenAndRefreshToken()
    {
        var testServer = new IntegrationTestServer();
        var email = "spynrt@gmail.com";
        var password = "S4$roNg)9";
        var createdUser = await testServer.CreateCustomer(email, password);
        var authenticationCommand = new AuthenticateUser.AuthenticateUserCommand
        {
            Email = email,
            Password = password
        };

        var result = await testServer.Post<AuthenticateUser.AuthenticateUserResult>("/api/authentication", authenticationCommand);
        
        Assert.NotNull(result);
        Assert.NotNull(result.Token);
        Assert.NotNull(result.RefreshToken);
        Assert.IsNotEmpty(result.Token);
        Assert.IsNotEmpty(result.RefreshToken);
    }
}