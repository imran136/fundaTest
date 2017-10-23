using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;

namespace FundaAssignment.Steps
{
    [Binding]
    public class BaseSteps
    {
        public static IWebDriver Driver { get; private set; }        

        [BeforeScenario("UI")]
        public static void BeforeScenario()
        {
            PrepareEnvironment();
        }

        [AfterScenario("UI")]
        public static void AfterScenario()
        {
            CloseTests();
        }

        public static void PrepareEnvironment()
        {
            
                var options = new InternetExplorerOptions
                {
                    UnexpectedAlertBehavior = InternetExplorerUnexpectedAlertBehavior.Ignore,
                    //IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                    //EnsureCleanSession = true,
                    IgnoreZoomLevel = true,
                    //EnableNativeEvents = false,
                    //options.ForceCreateProcessApi = true,
                    BrowserCommandLineArguments = "-private -extoff",

                };
                //Driver = new InternetExplorerDriver(options);
                Driver = new ChromeDriver(); 

            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("http://www.funda.nl/");

        }

        public static void CloseTests()
        {
            
            Driver?.Quit();
            
        }

    }
}