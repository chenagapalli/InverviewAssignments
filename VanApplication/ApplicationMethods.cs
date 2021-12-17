using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VanApplication
{

    public class ApplicationMethods : HelperMethods
    {
        IWebDriver driver = null;
        public ApplicationMethods(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void NavigateToVanFinances()
        {
            HandleCookPopup();

            ClickOnServices();

            ClickOnVanFinancesOption();

            ClickOnViewAllDeals();

            VerifyIfLandedOnUsedVehiclePage();

            FindTheCheapestDeal();
            VerifyThePriceFindMore();
        }
        public void HandleCookPopup()
        {
            WaitForElement(By.XPath("//div[@id='onetrust-button-group-parent']//button[text()='Accept All Cookies']")).Click();
        }
        public void ClickOnServices()
        {
            ClickElement(By.XPath("//nav[@class='main-nav b2cnav']//li//a[text()='Services ']"));
        }

        public void ClickOnVanFinancesOption()
        {
            ClickElement(By.XPath("//a[text()='Van Finance']"));
        }

        public void ClickOnViewAllDeals()
        {
            ClickElement(By.XPath("//a[text()='View All Deals']"));
        }


        public bool VerifyIfLandedOnUsedVehiclePage()
        {
            var element = driver.FindElement(By.XPath("//h2[text()='Used Vehicles']"));

            if (element.Text == "Used Vehicles")
            {
                Console.WriteLine("Successfully landed on Used Vehicle Page");
                return true;
            }
            else
            {
                Console.WriteLine("Failed to landed on Used Vehicle Page");
                return false;
            }
        }

        public void FindTheCheapestDeal()
        {
            var elements = driver.FindElements(By.XPath("//div[@class='block__body']//div[@class='col-33 col-m-33 col-s-100 van-feature-container']"));

            var prices = driver.FindElements(By.XPath("//div[@class='block__body']//div[@class='col-33 col-m-33 col-s-100 van-feature-container']//span[contains(text(),'VAT')]")).ToList();
            var values = prices.Select(x => x.Text).ToList();

            List<string> list = new List<string>();
            StringBuilder stb = null;
            foreach (string str in values)
            {
                stb = new StringBuilder();
                foreach (char ch in str)
                {
                    try
                    {
                        int temp = int.Parse(ch.ToString());

                        stb.Append(temp);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
                list.Add(stb.ToString());
            }

            var cheapDeal = list.Min(x => x);//int.Parse(list[0]);

            var finalCheapDeal = cheapDeal.ToString().Insert(0, "£").Insert(3, ",");
            finalCheapDeal += "+VAT";
            var cheapXpath = $"//div[@class='block__body']//div[@class='col-33 col-m-33 col-s-100 van-feature-container']//span[contains(text(),'{finalCheapDeal}')]/parent::div/following-sibling::div/a";
            driver.FindElement(By.XPath(cheapXpath)).Click();

        }

        public void VerifyThePriceFindMore()
        {
            var price = driver.FindElement(By.XPath("//strong[text()='£18,595']"));
            if (price != null)
            {
                Console.WriteLine("Values are as expected");
            }
            else
            {
                Console.WriteLine("Values are not as expected");
            }
        }
    }
}