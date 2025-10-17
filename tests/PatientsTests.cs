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
    [Category("Suite: Patients")]
    [Category("Regression Tests")]
    public class PatientsTests : TestBase
    {
        

        private IPage page;

        [SetUp]
        public async Task Setup()
        {
            page = await OpenBrowserAsync();
            var login = new LoginPage(page);
            await login.Login();
        }
        [TearDown]
        public async Task TearDown()
        {
            await CloseBrowserAsync();
        }

        [Test]
        public async Task Should_Do_CRUD_of_Patients()
        {
            var patients = new PatientsPage(page);
            await patients.RegisterNewPatient();
        }

    }
}
