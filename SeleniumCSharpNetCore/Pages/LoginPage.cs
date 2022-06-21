using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharpNetCore.Pages
{
    public class LoginPage : DriverHelper
    {
        IWebElement txtUserName => Driver.FindElement(By.Id("UserName"));
        IWebElement txtpwd => Driver.FindElement(By.Name("Password"));

        IWebElement btnlogin => Driver.FindElement(By.CssSelector(".btn-default"));


        public void EnterUserNameAndPassword (string userName, string password)
        {
            txtUserName.SendKeys("admin");
            txtpwd.SendKeys("password");
        }
        public void ClickLogin()
        {
            btnlogin.Click();
        
        }
    }
}
