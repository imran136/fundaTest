using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundaAssignment.Pages
{
    class SearchPage
    {
        private IWebDriver driver;
        private readonly By searchPageLocator = By.ClassName("search-result");        

        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(45));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            wait.Until(ExpectedConditions.ElementExists(searchPageLocator));
        }
        public bool IsPageDisplayed()
        {            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(45));
            wait.Until(ExpectedConditions.ElementExists(searchPageLocator));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(searchPageLocator));

            try
            {
                return element.Displayed;
            }
            catch (StaleElementReferenceException)
            {
                return IsPageDisplayed();
            }
        }

        public bool IsSearchResulstDisplayed(string searchResult)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(45));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[contains(.,'"+ searchResult + "')]")));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(.,'" + searchResult + "')]")));

            try
            {
                return element.Displayed;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        }

    }
}
