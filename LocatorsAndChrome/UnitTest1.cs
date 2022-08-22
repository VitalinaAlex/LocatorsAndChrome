using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.DevTools;

namespace LocatorsAndChrome

{
    public class Tests
    {
        private IWebDriver driver;
        private readonly String test_url = "https://accounts.ukr.net/login";

        private const string email = "_vitalina@ukr.net";
        private const string login = "autotest001@ukr.net";
        private const string password = "001autotest";
        //By.XPath("//input[@name='login']"
        private readonly By InputLogin = By.Name("login");
        private readonly By InputPassword = By.Name("password");
        private readonly By SignInButton = By.XPath("//button[@type='submit']");
        private readonly By ComposeLetterButton = By.XPath("//button[contains(text(),'Compose')]");
        private readonly By InputToButton = By.XPath("//input[@name='toFieldInput']");
        private readonly By InputSubjectButton = By.XPath("//input[@name='subject']");
        private readonly By InputLetterText = By.Id("editLinkBlock");
        private readonly By SendButton = By.XPath("//button[(text()='Send')]");


        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl(test_url);
            driver.Manage().Window.Maximize();
        }
        [Test]
        public void SendingTestLetter()
        {
                driver.FindElement(InputLogin).SendKeys(login);
                driver.FindElement(InputPassword).SendKeys(password);
                driver.FindElement(SignInButton).Click();
                Thread.Sleep(1500);
                driver.FindElement(ComposeLetterButton).Click();
                driver.FindElement(InputToButton).SendKeys(email);
                driver.FindElement(InputSubjectButton).SendKeys("Test");
            /*                IWebElement LetterText = driver.FindElement(InputLetterText);

                        Thread.Sleep(1500);
                        LetterText.SendKeys("Test letter");*/
            driver.FindElement(SendButton).Click();
        }

        [TearDown]
        public void close_Browser()
        {
            driver.Quit();
        }
    }
}
