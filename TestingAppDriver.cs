using System;
using System.IO;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using TechTalk.SpecFlow;

namespace testingbot_specflow
{
    [Binding]
    public sealed class testingbot_specflow
    {
        private TestingBotDriver tbDriver;

        [BeforeScenario]
        public void BeforeScenario()
        {
            tbDriver = new TestingBotDriver(ScenarioContext.Current);
            ScenarioContext.Current["tbDriver"] = tbDriver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            tbDriver.Cleanup();
        }
    }

    public class TestingBotDriver
    {
        private AppiumDriver<AndroidElement> driver;
        private ScenarioContext current;

        public TestingBotDriver(ScenarioContext current)
        {
            this.current = current;
        }

        public AppiumDriver<AndroidElement> Init()
        {
            var myJsonString = File.ReadAllText("test_settings.json");
            var myJObject = JObject.Parse(myJsonString);
            var appiumHost = myJObject.SelectToken("$.LOCAL.host").Value<string>();
            var androidApp = myJObject.SelectToken("$.LOCAL.android.app").Value<string>();
            var androidDevice = myJObject.SelectToken("$.LOCAL.android.deviceName").Value<string>();
            var platformVersion = myJObject.SelectToken("$.LOCAL.android.platformVersion").Value<string>();

            AppiumOptions appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("appium:automationName", "UiAutomator2");
            appiumOptions.AddAdditionalCapability("appium:deviceName", androidDevice);
            appiumOptions.AddAdditionalCapability("appium:platformVersion", platformVersion);
            appiumOptions.AddAdditionalCapability("appium:app", androidApp);
            appiumOptions.AddAdditionalCapability("appium:ensureWebviewsHavePages", true);
            appiumOptions.AddAdditionalCapability("appium:autoGrantPermissions", true);
            appiumOptions.AddAdditionalCapability("appium:noReset", false);
            AppiumDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                new Uri(appiumHost), appiumOptions);
            Console.WriteLine("Android Local Test");
            return driver;
        }
        [AfterTestRun]
        public void Cleanup()
        {
            if (this.driver != null)
            {
                this.driver.Quit();
                this.driver.Dispose();
                
            }
        }
    }
}
