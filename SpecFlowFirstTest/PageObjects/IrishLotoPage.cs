using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowFirstTest.PageObjects
{
    class IrishLotoPage
    {
        private readonly IButton resultsBtn = AqualityServices.Get<IElementFactory>().GetButton(By.XPath("//a[@data-actionable='Lotto.SelectLottoBanner.Results']"), "Results");

        public void ClickResultsButton()
        {
            resultsBtn.ClickAndWait();
        }
    }
}
