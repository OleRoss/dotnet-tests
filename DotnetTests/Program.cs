using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

// ReproStep1();
ReproStep2();

void ReproStep1()
{
    var filePath = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
    _ = new HostBuilder()
        .ConfigureAppConfiguration(builder =>
        {
            builder.AddJsonFile(filePath, optional: true, reloadOnChange: true);
        })
        .Build();
}

void ReproStep2()
{
    var provider = new PhysicalFileProvider(AppContext.BaseDirectory);
    _ = provider.Watch("appsettings.json");
}

