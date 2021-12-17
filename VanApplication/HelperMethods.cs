using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanApplication
{
    public class HelperMethods
    {
        IWebDriver driver = null;
        public HelperMethods(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement WaitForElement(By xpath)
        {
            int count = 10;
            IWebElement element = null;
            while (count > 0)
            {
                try
                {
                    if (driver.FindElement(xpath).Displayed)
                    {
                        element = driver.FindElement(xpath);
                        break;
                    }

                    if (count <= 0)
                    {
                        throw new Exception();
                    }
                }
                catch(Exception ex)
                {

                }
            }

            return element;
        }

        public void ClickElement(By xpath)
        {
          var element =  WaitForElement(xpath);
            try
            {
                if (element != null)
                {
                    element.Click();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"{ex.Message}");
            }
        }

        public void SetElement(By xpath, string value)
        {
            var element = WaitForElement(xpath);
            try
            {
                if (element != null)
                {
                    element.SendKeys(value);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        public string GetElement(By xpath)
        {
            string value = null;
            var element = WaitForElement(xpath);
            try
            {
                if (element != null)
                {
                    value = element.Text;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            return value;
        }
    }
}