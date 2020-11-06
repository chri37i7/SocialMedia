using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Azure.Identity;
using Microsoft.Extensions.Configuration;
using System;

namespace SocialMedia.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    Uri keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("VaultUri"));
                    config.AddAzureKeyVault(
                    keyVaultEndpoint,
                    new DefaultAzureCredential());
                })
                .ConfigureWebHostDefaults(webBuilder => 
                { 
                    webBuilder.UseStartup<Startup>(); 
                });
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
        }
    }
}