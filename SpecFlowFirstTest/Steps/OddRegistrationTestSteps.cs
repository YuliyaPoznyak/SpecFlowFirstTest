using Aquality.Selenium.Browsers;
using OddSkingTest.PageObjects;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlowFirstTest.Steps
{
    [Binding]
    public class OddRegistrationTestSteps
    {
        private MainPage mainPage = new MainPage();
        private RegistrationPage registrationPage = new RegistrationPage();
        private DateTime now = DateTime.Now;
        private string mailEndPoints = "@mail.ru";
        private Browser browser = AqualityServices.Browser;
        

        [Given(@"I am on the main page ""(.*)""")]
        public void GivenIAmOnTheMainPage(string url)
        {
            browser.Maximize();
            browser.GoTo(url);
            browser.WaitForPageToLoad();
        }

        [Given(@"click join button")]
        public void GivenClickJoinButton()
        {
            mainPage.ClickJoinButton();
        }
        
        [When(@"email, username, password are entered")]
        public void WhenEmailUsernamePasswordAreEntered(Dictionary<string, string> dictionary)
        {
            var email = dictionary["Email Address"] + now.ToString("hhmmss") + mailEndPoints;
            var username = dictionary["Username"] + now.ToString("hhmmss");
            registrationPage.EnterEmail(email);
            registrationPage.EnterPassword(dictionary["Password"]);
            registrationPage.EnterUsername(username);
        }
        
        [When(@"Conditions are accepted")]
        public void WhenConditionsAreAccepted()
        {
            registrationPage.AcceptTermsAndConditions();
        }
        
        [When(@"Click Continue button")]
        public void WhenClickContinueButton()
        {
            registrationPage.ClickContinueButton();
        }
        
        [When(@"I enter title, first name, last name, date of birth")]
        public void WhenIEnterTitleFirstNameLastNameDateOfBirth(Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            registrationPage.ChooseTitle(dictionary["Title"]);
            registrationPage.EnterFirstName(dictionary["First Name"]);
            registrationPage.EnterLastName(dictionary["Last Name"]);
            registrationPage.EnterDateOfBirth(dictionary["Date of birth"]);
        }
        
        [When(@"I enter contact data")]
        public void WhenIEnterContactData(Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            registrationPage.EnterTelephoneNumber(dictionary["Telephone"]);
            registrationPage.ChooseSecurityQuestion(dictionary["Security Question"]);
            registrationPage.EnterAnswer(dictionary["Answer"]);
        }
        
        [When(@"I entered address")]
        public void WhenIEnteredAddress(Table table)
        {
            registrationPage.ClickOutsideTheUK();
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            foreach(var(elementId, value) in dictionary)
            {
                registrationPage.EnterAddressData(elementId, value);
            }
        }
        
        [When(@"No marketing option is shosen in promotions")]
        public void WhenNoMarketingOptionIsShosenInPromotions()
        {
            registrationPage.ChooseNoMarketing();
        }
        
        [When(@"Click Register button")]
        public void WhenClickRegisterButton()
        {
            registrationPage.ClickRegistrationButton();
        }
        
        [Then(@"registration form is displayed")]
        public void ThenRegistrationFormIsDisplayed()
        {
            AqualityServices.ConditionalWait.WaitForTrue(() => registrationPage.IsAccountSectionDisplayed());
            Assert.True(registrationPage.IsAccountSectionDisplayed(), "Account section is not displayed");
        }
        
        [Then(@"Form with personal information is displayed")]
        public void ThenFormWithPersonalInformationIsDisplayed()
        {
            AqualityServices.ConditionalWait.WaitForTrue(() => registrationPage.IsPersonalInfoSectionDisplayed());
            Assert.True(registrationPage.IsPersonalInfoSectionDisplayed(), "Account section is not displayed");
        }
        
        [Then(@"Form with contacts is displayed")]
        public void ThenFormWithContactsIsDisplayed()
        {
            AqualityServices.ConditionalWait.WaitForTrue(() => registrationPage.IsTelephoneNoSectionDisplayed());
            Assert.True(registrationPage.IsTelephoneNoSectionDisplayed(), "Telephone number section is not displayed");
        }
        
        [Then(@"Form with address is displayed")]
        public void ThenFormWithAddressIsDisplayed()
        {
            AqualityServices.ConditionalWait.WaitForTrue(() => registrationPage.IsAddressSectionDisplayed());
            Assert.True(registrationPage.IsAddressSectionDisplayed(), "Address section is not displayed");
        }
        
        [Then(@"Settings form is displayed")]
        public void ThenSettingsFormIsDisplayed()
        {
            Assert.True(registrationPage.IsSettingsSectionDisplayed(), "Settings section is not displayed");
        }
        
        [Then(@"Registration is successfull")]
        public void ThenRegistrationIsSuccessfull()
        {
            Assert.True(registrationPage.IsRegistrationResultDisplayed(), "Registration result is not shown");
            browser.Quit();
        }
    }
}
