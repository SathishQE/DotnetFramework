using Microsoft.Playwright;
using Automation.SwagLabsNET.Pom;
using Automation.SwagLabsNET.Extensions;
using static System.Net.Mime.MediaTypeNames;

using Automation.SwagLabsNET.Extensions.PlaywrightExtensions;
using Automation.SwagLabsNET.Pom.Constants;

namespace Automation.SwagLabsNET.Test
{
    public static class GetPage
    {
        private static IPage page;

        public static async Task<IPage> GetWebPage() 
        { 
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
