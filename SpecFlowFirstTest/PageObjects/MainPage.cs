using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace OddSkingTest.PageObjects
{
    class MainPage
    {
        private IButton joinBtn = AqualityServices.Get<IElementFactory>().GetButton(By.XPath("//a[contains(@href, 'registration')]"), "Join");

        public void ClickJoinButton()
        {
            joinBtn.ClickAndWait();
        }
    }
}
