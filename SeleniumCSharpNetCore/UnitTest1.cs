using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumCSharpNetCore.Pages;
using System.Reflection;

namespace SeleniumCSharpNetCore
{
    public class Tests : DriverHelper
    {


        [SetUp]
        public void Setup()
        {
            Console.WriteLine("SetUp");
            Driver = new ChromeDriver();
        }

        [Test]
        public void Test1()
        {

            Driver.Navigate().GoToUrl("https://demowf.aspnetawesome.com");

            Driver.FindElement(By.Id("ContentPlaceHolder1_Meal")).SendKeys("Tomato");

            Driver.FindElement(By.XPath("//input[@name='ctl00$ContentPlaceHolder1$ChildMeal1']/following-sibling::div[text()='Celery']")).Click();

            CustomControl.ComboBox("ContentPlaceHolder1_AllMealsCombo", "Almond");


            //Taking ScreenShot
            var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).ToString();
            var screenshot = (Driver as ITakesScreenshot).GetScreenshot();
            screenshot.SaveAsFile($"{dir}\\screenshot" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".png");


            //((ITakesScreenshot)Driver).GetScreenshot().SaveAsFile("Snapshot" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".png", ScreenshotImageFormat.Png);

            Assert.Pass();
           
        }

        [Test]
        public void LoginTest()
        {
            Driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            HomePage homePage = new HomePage();
            LoginPage loginPage = new LoginPage();
            homePage.ClickLogin();
            loginPage.EnterUserNameAndPassword("admin", "password");
            loginPage.ClickLogin();
            Assert.That(homePage.IsLogOffExist, Is.True, "Log off button not displayed");
        }
    }
}