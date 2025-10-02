using System;
using HerokuappUiTests.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HerokuappUiTests
{
    public class BaseTest
    {
        // Подавляем только для поля драйвера правило NUnit1032 (IDisposable field should be disposed)
#pragma warning disable NUnit1032
        private IWebDriver? _driver;
#pragma warning restore NUnit1032

        private WebDriverWait? _wait;

        protected IWebDriver Driver => _driver ?? throw new NullReferenceException("Driver not initialized");
        protected WebDriverWait Wait => _wait ?? throw new NullReferenceException("Wait not initialized");

        protected const string BaseUrl = "http://the-internet.herokuapp.com";

        [SetUp]
        public void SetUp()
        {
            _driver = DriverFactory.CreateChrome(false);
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.Zero;

            // Явные ожидания: 10s, polling 200ms
            _wait = new WebDriverWait(new SystemClock(), _driver,
                TimeSpan.FromSeconds(10), TimeSpan.FromMilliseconds(200));
        }
        [TearDown]
        public void TearDown()
        {
            try
            {
                _driver?.Quit();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при завершении драйвера: {ex.Message}");
            }
            finally
            {
                _wait = null;
                _driver = null;
            }
        }
    }
}
