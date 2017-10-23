using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundaAssignment.Pages
{
    class HomePage
    {
        private IWebDriver driver;
        private readonly By homePageLocator = By.ClassName("home-search");        
        private readonly string pageUrl = "https://www.funda.nl/";

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(45));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            wait.Until(ExpectedConditions.ElementExists(homePageLocator));
        }
        public bool IsPageDisplayed()
        {
            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(45));
            wait.Until(ExpectedConditions.ElementExists(homePageLocator));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(homePageLocator));

            try
            {
                return element.Displayed;
            }
            catch (StaleElementReferenceException)
            {
                return IsPageDisplayed();
            }
        }

        public void CategoryIsSelected(string category)
        {
            driver.Url = pageUrl+category;           

        }

        public IWebElement SearchButton()
        {
            By searchButton = By.ClassName("button-primary-alternative");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(45));
            return wait.Until(ExpectedConditions.ElementToBeClickable(searchButton));
        }
    }
}
