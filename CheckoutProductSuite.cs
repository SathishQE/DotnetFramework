using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.SwagLabsNET.Test
{
    [TestFixture]
    public class CheckoutProductSuite
    {
        IPage _page;

        [OneTimeSetUp]
        public async Task Setup()
        {
            _page = await GetPage.GetWebPage();
        }

        [Test]
        public void Verify_CheckoutProduct_Workflow()
        {
            Assert.Pass();
        }

        [OneTimeTearDown]
        public async Task TearDown()
        {
            await _page.CloseAsync();
        }
    }
}
