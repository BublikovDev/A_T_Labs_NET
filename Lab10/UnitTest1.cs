using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Lab10
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Test]
        public void userNameInteraction()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/text-box");


            Task.Delay(5000).Wait();
            var usernameField = _driver.FindElement(By.Id("userName"));
            usernameField.SendKeys("Kyrylo");

            Task.Delay(5000).Wait();

            var result = _driver.FindElement(By.Id("userName"));


            Assert.AreEqual("Kyrylo", result.Text);
        }

        [Test]
        public void emailInteraction()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/text-box");


            Task.Delay(5000).Wait();
            var userEmailField = _driver.FindElement(By.Id("userEmail"));
            userEmailField.SendKeys("bublikov.dev@gmail.com");

            Task.Delay(5000).Wait();

            var result = _driver.FindElement(By.Id("userEmail"));


            Assert.AreEqual("bublikov.dev@gmail.com", result.Text);
        }

        [Test]
        public void currentAddressInteraction()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/text-box");


            Task.Delay(5000).Wait();
            var currentAddressField = _driver.FindElement(By.Id("currentAddress"));
            currentAddressField.SendKeys("Lviv, Ukraine");

            Task.Delay(5000).Wait();

            var result = _driver.FindElement(By.Id("currentAddress"));


            Assert.AreEqual("Lviv, Ukraine", result.Text);
        }

        [Test]
        public void permanentAddressInteraction()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/text-box");


            Task.Delay(5000).Wait();
            var permanentAddressField = _driver.FindElement(By.Id("permanentAddress"));
            permanentAddressField.SendKeys("Kyiv, Ukraine");

            Task.Delay(5000).Wait();

            var result = _driver.FindElement(By.Id("permanentAddress"));


            Assert.AreEqual("Kyiv, Ukraine", result.Text);
        }


        [Test]
        public void SubmitInteraction()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/text-box");

            
            Task.Delay(5000).Wait();



            var usernameField = _driver.FindElement(By.Id("userName"));
            usernameField.SendKeys("Kyrylo");
            var userEmailField = _driver.FindElement(By.Id("userEmail"));
            userEmailField.SendKeys("bublikov.dev@gmail.com");
            var currentAddressField = _driver.FindElement(By.Id("currentAddress"));
            currentAddressField.SendKeys("Lviv, Ukraine");
            var permanentAddressField = _driver.FindElement(By.Id("permanentAddress"));
            permanentAddressField.SendKeys("Kyiv, Ukraine");


            var button = _driver.FindElement(By.Id("submit"));
            button.Click();

            Task.Delay(5000).Wait();

            var usernameFieldResult = _driver.FindElement(By.Id("name"));
            var userEmailFieldResult = _driver.FindElement(By.Id("email"));
            var currentAddressResult = _driver.FindElement(By.Id("currentAddress"));
            var permanentAddressResult = _driver.FindElement(By.Id("permanentAddress"));


            Assert.AreEqual("Name:Kyrylo", usernameFieldResult.Text);
            Assert.AreEqual("Email:bublikov.dev@gmail.com", userEmailFieldResult.Text);
            Assert.AreEqual("Current Address :Lviv, Ukraine", currentAddressResult.Text);
            Assert.AreEqual("Permananet Address :Kyiv, Ukraine", permanentAddressResult.Text);
        }

    }
}