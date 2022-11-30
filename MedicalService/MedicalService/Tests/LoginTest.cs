using MedicalService.Driver;
using MedicalService.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalService.Tests
{
    public class LoginTest
    {
        LoginPage loginPage;
        string Message = "Login failed! Please ensure the username and password are valid.";

        [SetUp]
        public void Setup()
        {
            WebDrivers.Initialize();
            loginPage = new LoginPage();
        }
        [TearDown]
        public void Close()
        {
            WebDrivers.CleanUp();
        }
        [Test]
        public void TC01_EnterInvalidUserName_ShouldNotBeLoginONPage()
        {
            loginPage.AppMedic.Click();
            loginPage.Login("Spale", "ThisIsNotAPassword");
            Assert.That("Login failed! Please ensure the username and password are valid.",Is.EqualTo(loginPage.UserNotLogin.Text));
        }

        [Test]
        public void TC02_EnterInvalidPassword_ShouldNotBeLoginONPage()
        {
            loginPage.AppMedic.Click();
            loginPage.Login("John Doe", "ThisIsNotATruePassword");
            Assert.That(Message,Is.EqualTo(loginPage.UserNotLogin.Text));
        }

        [Test]
        public void TC0_EnterNoData_ShouldNotBeLoginONPage()
        {
            loginPage.AppMedic.Click();
            loginPage.Login("", "");
            Assert.That(Message, Is.EqualTo(loginPage.UserNotLogin.Text));
        }
    }
}
