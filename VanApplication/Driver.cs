using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanApplication
{
    public class Driver
    {
        IWebDriver driver;

        public Driver()
        {

        }
        public IWebDriver GetDriver()
        {
            try
            {
                driver = new ChromeDriver();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"{ex.Message}");
            }

            return driver;
        }

        public void NavigateToUrl()
        {
            try
            {
                driver.Navigate().GoToUrl("https://insyncgroup.co.uk");
                driver.Manage().Window.Maximize();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
    }
}