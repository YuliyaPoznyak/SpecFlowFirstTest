using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace OddSkingTest.PageObjects
{
    class RegistrationPage
    {
        private const string accountSection = "RegistrationPage.AccountSection";
        private const string personalInfoSection = "RegistrationPage.PersonalSection";
        private const string contactInfoSection = "RegistrationPage.TelephoneNumberInput.telephone.desktop-telephone";
        private const string contactSection = "RegistrationPage.ContactSection";
        private const string addressSection = "RegistrationPage.search_address";
        private const string addressEditor = "RegistrationPage.AddressEditor";
        private const string marketing = "//div[contains(@data-actionable, 'RegistrationPage.PromotionsSelector.No Marketing')]";

        private readonly ILabel accountSectionLbl = AqualityServices.Get<IElementFactory>().GetLabel(By.XPath($"//div[contains(@data-actionable, '{accountSection}')]"), "Account section");
        private readonly ILabel personalInfoLbl = AqualityServices.Get<IElementFactory>().GetLabel(By.XPath($"//div[contains(@data-actionable, '{personalInfoSection}')]"), "Personal information section");
        private readonly ILabel settingsSectionLbl = AqualityServices.Get<IElementFactory>().GetLabel(By.XPath("//div[contains(@data-actionable, 'RegistrationPage.SettingsSection.promotionSection')]"), "Settings section");
        private readonly ILabel registrationLbl = AqualityServices.Get<IElementFactory>().GetLabel(By.XPath("//h5[contains(text(), Registration)]"), "Registration result");
        private ITextBox AddressDataTxb(string elementId) => AqualityServices.Get<IElementFactory>().GetTextBox(By.Id(addressEditor+elementId), "Address data");
        private readonly ITextBox emailTxb = AqualityServices.Get<IElementFactory>().GetTextBox(By.Id(accountSection + ".email"), "Email address");
        private readonly ITextBox usernameTxb = AqualityServices.Get<IElementFactory>().GetTextBox(By.Id(accountSection +".username"), "Username");
        private readonly ITextBox passwordTxb = AqualityServices.Get<IElementFactory>().GetTextBox(By.Id(accountSection + ".password"), "Password");
        private readonly ITextBox firstNameTxb = AqualityServices.Get<IElementFactory>().GetTextBox(By.Id(personalInfoSection + ".first_name"), "First name");
        private readonly ITextBox lastNameTxb = AqualityServices.Get<IElementFactory>().GetTextBox(By.Id(personalInfoSection + ".last_name"), "Last name");
        private readonly ITextBox dateOfBirthTxb = AqualityServices.Get<IElementFactory>().GetTextBox(By.Id("RegistrationPage.DateOfBirthInput.day"), "Date of birth");
        private readonly ITextBox telephoneTxb = AqualityServices.Get<IElementFactory>().GetTextBox(By.Id(contactInfoSection), "Telephone No");
        private readonly ITextBox answerTxb = AqualityServices.Get<IElementFactory>().GetTextBox(By.Id(contactSection + ".desktop_security_answer"), "Answer");
        private readonly ITextBox addressTxb = AqualityServices.Get<IElementFactory>().GetTextBox(By.XPath($"//input[contains(@data-actionable, '{addressSection}')]"), "Address");
        private IButton continueBtn = AqualityServices.Get<IElementFactory>().GetButton(By.XPath("//button[contains(@data-actionable, 'Continue')]"), "Continue");
        private readonly IButton securityQuestionArrowBtn = AqualityServices.Get<IElementFactory>().GetButton(By.Id("RegistrationPage.Dropdown.desktop-securityQuestion"), "Arrow to choose security questions");
        private readonly IButton outsideTheUKBtn = AqualityServices.Get<IElementFactory>().GetButton(By.XPath("//button[@data-actionable='InputLabel.outsidetheuk?']"), "Outside the UK?");
        private readonly IButton registrationBtn = AqualityServices.Get<IElementFactory>().GetButton(By.XPath("//button[contains(@data-actionable, 'RegistrationPage.NavigationButtonsPage5.Register')]"), "Registration");
        private readonly ICheckBox acceptTermsChb = AqualityServices.Get<IElementFactory>().GetCheckBox(By.XPath("//div[contains(@data-actionable, 'agree_terms')]"), "Accept terms and conditions");
        private readonly ICheckBox oddskingChb = AqualityServices.Get<IElementFactory>().GetCheckBox(By.XPath($"//label[@for='firstParty-No Marketing-checkbox']{marketing}"), "Oddsking no marketing");
        private readonly ICheckBox fromFriendsChb = AqualityServices.Get<IElementFactory>().GetCheckBox(By.XPath($"//label[@for='thirdParty-No Marketing-checkbox']{marketing}"), "From friends no marketing");

        private IButton getTitleButton(string title)
        {
            return AqualityServices.Get<IElementFactory>().GetButton(By.XPath($"//button[@value= '{title}']"), "Title");
        }

        private IButton getSecurityQuestionButton(string question)
        {
            return AqualityServices.Get<IElementFactory>().GetButton(By.XPath($"//select[@name='desktop-securityQuestion']//option[contains(@value, '{question}')]"), "Security Question");
        }
        public bool IsAccountSectionDisplayed()
        {
            return accountSectionLbl.State.IsDisplayed;
        }

        public bool IsPersonalInfoSectionDisplayed()
        {
            return personalInfoLbl.State.IsDisplayed;
        }

        public void EnterEmail(string email)
        {
            emailTxb.ClearAndType(email);
        }

        public void EnterUsername(string username)
        {
            usernameTxb.ClearAndType(username);
        }

        public void EnterPassword(string password)
        {
            passwordTxb.ClearAndType(password);
        }

        public void EnterFirstName(string firstName)
        {
            firstNameTxb.ClearAndType(firstName);
        }

        public void EnterLastName(string lastName)
        {
            lastNameTxb.ClearAndType(lastName);
        }

        public void EnterDateOfBirth(string dateOfBirth)
        {
            dateOfBirthTxb.ClearAndType(dateOfBirth);
        }

        public void AcceptTermsAndConditions()
        {
            acceptTermsChb.Check();
        }

        public void ClickContinueButton()
        {
            //AqualityServices.Browser.ExecuteScript("arguments[0].click();", continueBtn);
            //AqualityServices.ConditionalWait.WaitForTrue(() => continueBtn.State.IsClickable);
            //continueBtn.ClickAndWait();
            continueBtn.WaitAndClick();
        }

        public void ChooseTitle(string title)
        {
            getTitleButton(title).Click();
        }

        public void EnterTelephoneNumber(string telephone)
        {
            telephoneTxb.ClearAndType(telephone);
        }

        public void ChooseSecurityQuestion(string question)
        {
            securityQuestionArrowBtn.Click();
            getSecurityQuestionButton(question).Click();
        }

        public void EnterAnswer(string answer)
        {
            answerTxb.ClearAndType(answer);
        }

        public bool IsTelephoneNoSectionDisplayed()
        {
            return telephoneTxb.State.IsDisplayed;
        }

        public bool IsAddressSectionDisplayed()
        {
            return addressTxb.State.IsDisplayed;
        }

        public void ChooseAddress(string address)
        {
            addressTxb.ClearAndType(address);
        }

        public void ClickOutsideTheUK()
        {
            outsideTheUKBtn.ClickAndWait();
        }

        public void EnterAddressData(string elementId, string value)
        {
            AddressDataTxb(elementId).ClearAndType(value);
        }

        public void ClickRegistrationButton()
        {
            AqualityServices.ConditionalWait.WaitForTrue(() => registrationBtn.State.IsClickable);
            registrationBtn.ClickAndWait();
        }

        public bool IsSettingsSectionDisplayed()
        {
            AqualityServices.ConditionalWait.WaitForTrue(() => settingsSectionLbl.State.IsDisplayed);
            return settingsSectionLbl.State.IsDisplayed;
        }

        public void ChooseNoMarketing()
        {
            oddskingChb.Check();
            fromFriendsChb.Check();
        }

        public bool IsRegistrationResultDisplayed()
        {
            AqualityServices.ConditionalWait.WaitForTrue(() => registrationLbl.State.IsDisplayed);
            return registrationLbl.State.IsDisplayed;
        }
    }
}
