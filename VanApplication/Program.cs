using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Linq;
using University;

namespace VanApplication
{
    class Program
    {

        static void Main(string[] args)
        {
            //Assignment One
            var driverobj = new Driver();
            var driver = driverobj.GetDriver();

            driver.Navigate().GoToUrl("https://insyncgroup.co.uk");
            driver.Manage().Window.Maximize();

            ApplicationMethods application = new ApplicationMethods(driver);

            application.NavigateToVanFinances();

            //Assignment two

            HttpHelper helper = new HttpHelper();
            var universities = helper.GetUniversity();
            var notGB = universities.Where(x => x.AlphaTwoCode != "GB").Select(x =>x);
            if (notGB.Count() > 0)
            {
                Console.WriteLine($"Number of Alpha Two code without GB {notGB.Count()} \n");

                foreach(UniversityAPI.University university in notGB)
                {
                    Console.WriteLine(university.AlphaTwoCode +"\n");
                }
            }
            else
            {
                Console.WriteLine($"Number of Alpha Two code with out GB found non \n");
            }

            var domainNameWithIshtm = universities.Where(x => x.Domains.Contains("lshtm.ac.uk")).Select(x =>x);

            if (domainNameWithIshtm.Count() > 0)
            {
                Console.WriteLine($"Number domain name with lshtm.ac.uk {domainNameWithIshtm.Count()} \n");
                foreach (UniversityAPI.University university in domainNameWithIshtm)
                {
                    Console.WriteLine(university.Name + "\n");
                }
            }
        }
    }
}