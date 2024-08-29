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

        [SetUp]
        public async Task Setup()
        {
            _page = await GetPage.GetWebPage();
        }

        [Test]
        public void Verify_CheckoutProduct_Workflow()
        {
            Assert.Pass();
        }

        [TearDown]
        public async Task TearDown()
        {
            await _page.CloseAsync();
        }
    }
}
