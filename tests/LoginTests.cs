using Allure.Net.Commons;
using Allure.NUnit;
using Microsoft.Playwright;
using Ortogreen.pages;
using Ortogreen.runner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ortogreen.tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    [AllureNUnit]
    [Category("Criticality: Critical")]
    [Category("Regression Tests")]
    public class LoginTests : TestBase
    {
        private IPage page;

        [SetUp]
        public async Task Setup()
        {
            page = await OpenBrowserAsync();
        }
        [TearDown]
        public async Task TearDown()
        {
            await CloseBrowserAsync();
        }

        [Test, Order(1)]
        public async Task Should_Do_Login_With_Valid_Credentials()
        {
            var login = new LoginPage(page);
            await login.DoLogin();
        }
    }
}
