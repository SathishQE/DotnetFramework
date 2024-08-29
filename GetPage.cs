using Microsoft.Playwright;
using Automation.SwagLabsNET.Extensions.PlaywrightExtensions;
using Automation.SwagLabsNET.Pom.Constants;
using Microsoft.Extensions.Configuration;

namespace Automation.SwagLabsNET.Test
{
    public static class GetPage
    {
        private static IPage? page;
        private static IConfiguration? _config;

        public static async Task<IPage> GetWebPage() 
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
          
            _config = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.{environment}.json", reloadOnChange: true, optional: true)
                .Build();

            await Console.Out.WriteLineAsync($"environment: {environment}");

            Console.WriteLine(_config["Appsettings:username"]);
            Console.WriteLine(_config["Appsettings:password"]);

            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Channel = "chrome", Headless=false});
            page = await browser.NewPageAsync();

            await page.GotoAsync("https://www.saucedemo.com/");

            await page.FillTextBoxByPlaceholderAsync(LoginConstants.UserNamePlaceholderText, LoginConstants.UserName);
            await page.FillTextBoxByPlaceholderAsync(LoginConstants.PasswordPlaceholderText, LoginConstants.UserPassword);

            await page.ClickbuttonByLocatorAsync(LoginConstants.LogInButtonId);

            return page;
        }
    }
}
