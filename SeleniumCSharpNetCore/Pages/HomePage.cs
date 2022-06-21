using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharpNetCore.Pages
{
     class HomePage:DriverHelper
    {
        IWebElement lnklogin => Driver.FindElement(By.LinkText("Login"));

        IWebElement lnklogoff => Driver.FindElement(By.LinkText("Log off"));

        public void ClickLogin() => lnklogin.Click();

        public bool IsLogOffExist() => lnklogoff.Displayed;
    }
}
