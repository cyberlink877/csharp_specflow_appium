using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using TechTalk.SpecFlow;
using System.Threading;
using System;

namespace testingbot_specflow
{
    [Binding]
    public class SingleStep
    {
        private AppiumDriver<AndroidElement> _driver;
        readonly TestingBotDriver _tbDriver;

        public SingleStep()
        {
            _tbDriver = (TestingBotDriver) ScenarioContext.Current["tbDriver"];
        }

        [Given(@"I am using the testapp")]
        public void GivenIAmOnTheTestApp()
        {
            _driver = _tbDriver.Init();
	        _driver.FindElement(By.XPath("(//android.widget.ImageView[@resource-id=\"com.sec.android.app.launcher:id/iconview_imageView\"])[1]")).Click();
            Thread.Sleep(3000);
        }

        [When(@"I click on color button")]
        public void WhenIClickOnColor()
        {
            _driver.FindElement(By.Id("com.lambdatest.proverbial:id/color")).Click();
            Thread.Sleep(3000);
        }
        [Then(@"I check for font in pink")]
        public void ThenICheckForFontPink()
        {
            String returnedtext = _driver.FindElement(By.Id("com.lambdatest.proverbial:id/Textbox")).Text;
            Assert.That(returnedtext, Is.EqualTo("Hello! Welcome to lambdatest Sample App called Proverbial"));
            Thread.Sleep(1000);
            backtoHomePage();
        }
        [When(@"I click on text button")]
        public void WhenIClickOnText()
        {
            _driver.FindElement(By.Id("com.lambdatest.proverbial:id/Text")).Click();
            Thread.Sleep(3000);
        }
        [Then(@"I check for the returned text")]
        public void ThenICheckForReturnedText()
        {
            String returnedtext = _driver.FindElement(By.Id("com.lambdatest.proverbial:id/Textbox")).Text;
            Assert.That(returnedtext, Is.EqualTo("Proverbial"));
            Thread.Sleep(1000);
            backtoHomePage();

        }
        [When(@"I click on toast button")]
        public void WhenIClickOnToast()
        {
            _driver.FindElement(By.Id("com.lambdatest.proverbial:id/toast")).Click();
            Thread.Sleep(2000);
        }
        [Then(@"I check for the pop-up message for toast")]
        public void ThenICheckForMessagesForToast()
        {
            String returnedmessage = _driver.FindElement(By.XPath("//android.widget.Toast[@text=\"Toast should be visible\"]")).Text;
            Assert.That(returnedmessage, Is.EqualTo("Toast should be visible"));
            Thread.Sleep(1000);
            backtoHomePage();
        }
        [When(@"I click on geolocation button")]
        public void WhenIClickOnGeolocation()
        {
            _driver.FindElement(By.Id("com.lambdatest.proverbial:id/geoLocation")).Click();
            Thread.Sleep(3000);
        }
        [Then(@"I check for the search find button")]
        public void ThenICheckForSearchButton()
        {
            String foundbutton = _driver.FindElement(By.Id("com.lambdatest.proverbial:id/find")).Text;
            Assert.That(foundbutton, Is.EqualTo("FIND"));
            Thread.Sleep(1000);
            backtoHomePage();
        }
        [When(@"I click on notification button")]
        public void WhenIClickOnNotification()
        {
            _driver.FindElement(By.Id("com.lambdatest.proverbial:id/notification")).Click();
            Thread.Sleep(3000);
        }
        [Then(@"I check for notification message")]
        public void ThenICheckForNotificationMessages()
        {
            String returnedmessage = _driver.FindElement(By.Id("com.lambdatest.proverbial:id/notification")).Text;
            Assert.That(returnedmessage, Is.EqualTo("NOTIFICATION"));
            Thread.Sleep(1000);
            backtoHomePage();
        }
        [When(@"I click on speed test button")]
        public void WhenIClickOnSpeedTest()
        {
            _driver.FindElement(By.Id("com.lambdatest.proverbial:id/speedTest")).Click();
            Thread.Sleep(6000);
        }
        [Then(@"I check for speed test applications")]
        public void ThenICheckForSpeedTest()
        {
            String foundbutton = _driver.FindElement(By.Id("com.lambdatest.proverbial:id/find")).Text;
            Assert.That(foundbutton, Is.EqualTo("FIND"));
            Thread.Sleep(1000);
            backtoHomePage();
        }
        public void backtoHomePage()
        {
            //Go back to the home page
            _driver.FindElement(By.Id("com.lambdatest.proverbial:id/buttonPage")).Click();
            Thread.Sleep(3000);
        }

    }
}
