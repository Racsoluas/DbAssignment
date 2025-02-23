using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DatabaseConsole.Services;
using DatabaseConsole.UI;
using DatabaseConsole.Data;
using Microsoft.EntityFrameworkCore;

class Program
{
    static async Task Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        var menuManager = host.Services.GetRequiredService<MenuDialogs>();
        await menuManager.ShowMainMenu();
    }

    static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
            {
                services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(
                        "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Projects\\DatabaseAssignment\\DatabaseAssignment\\Databases\\localdatabase.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True"));
                
                services.AddScoped<ProjectService>();
                services.AddScoped<CustomerService>();
                services.AddScoped<ProjectManagerService>();
                
                services.AddSingleton<MenuDialogs>();
            });
}