namespace Common.Tests.Base;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

public abstract class ServerIntegrationTestBase : SqlIntegrationTestBase
{
    protected HttpClient Client { get; private set; } = null!;

    private WebApplicationFactory<Program> WebApplicationFactory { get; set; } = null!;

    [SetUp]
    public void SetUpServerIntegrationTestBase()
    {
        WebApplicationFactory = new WebApplicationFactory<Program>();
        WebApplicationFactory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureLogging(p => p.AddFilter(logLevel => logLevel >= LogLevel.Warning));
            builder.ConfigureServices(ConfigureServices);
        });

        Client = WebApplicationFactory.CreateClient();
    }

    public void ConfigureServices(IServiceCollection services)
    {
    }

    public async Task Login()
    {
        await Client.GetStringAsync("/account/login");
    }

    public new void Dispose()
    {
        WebApplicationFactory.Dispose();
        Client.Dispose();
        base.Dispose();
    }
}