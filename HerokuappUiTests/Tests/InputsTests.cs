using FluentAssertions;
using HerokuappUiTests.Mappings;
using HerokuappUiTests.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace HerokuappUiTests.Tests
{
    [TestFixture]
    public class InputsTests : BaseTest
    {
        private static readonly Regex Digits = new(@"^-?\d*$");

        [Test]
        public void Accepts_numeric_and_ignores_non_numeric_with_arrows()
        {
            Driver.Navigate().GoToUrl($"{BaseUrl}/inputs");
            var box = Wait.WaitVisible(InputsPage.Input);

            // принимает цифры
            box.Clear();
            box.SendKeys("123");
            box.GetAttribute("value").Should().Be("123");

            // не принимает буквы
            box.Clear();
            box.SendKeys("abc");
            box.GetAttribute("value").Should().BeEmpty("type=number не принимает буквы");

            // стрелки изменяют значение
            box.Clear();
            box.SendKeys("5");
            box.SendKeys(Keys.ArrowUp);
            box.GetAttribute("value").Should().Be("6");
            box.SendKeys(Keys.ArrowDown);
            box.GetAttribute("value").Should().Be("5");
        }
    }
}
