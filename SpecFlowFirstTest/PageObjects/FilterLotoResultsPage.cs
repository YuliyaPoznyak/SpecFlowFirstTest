using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Elements;
using Aquality.Selenium.Core.Forms;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SpecFlowFirstTest.PageObjects
{
    public class FilterLotoResultsPage : Form
    {
        private readonly ILabel filterResultsLbl = AqualityServices.Get<IElementFactory>().GetLabel(By.XPath("//div[contains(text(), 'Filter lotto results by date')]"), 
            "Filter results");
        private readonly ILabel resultsLbl = AqualityServices.Get<IElementFactory>().GetLabel(By.XPath("//div[contains(@class, '_nm44ia')]//div//div[contains(text(), ' - ')]"),
            "Filtered results by date");
        private IButton DateToBtn(string currentDate) => AqualityServices.Get<IElementFactory>().GetButton(By.XPath($"//div[@data-actionable='Lotto.ResultsDateFilter.SetDateTo']//div[contains(text(), '{currentDate}')]"), "Current date in filter");
        private IButton dateFromBtn = AqualityServices.Get<IElementFactory>().GetButton(By.XPath("//div[@data-actionable='Lotto.ResultsDateFilter.SetDateFrom']//div[not(contains(text(), 'FROM'))]"), "From date in filter");
        private IButton viewFilteredResultsBtn = AqualityServices.Get<IElementFactory>().GetButton(By.XPath("//button[@data-actionable='LottoApp.ResultsPage.DateFilter.submit']"), "View Filtered results");
        private IButton fromDateNextMonthBtn = AqualityServices.Get<IElementFactory>().GetButton(By.XPath("//button[contains(@class, 'react-calendar__navigation__next-button')]"), "Next month");
        private IButton CalendarDayBtn(string day) => AqualityServices.Get<IElementFactory>().GetButton(By.XPath($"//button//abbr[text()='{day}']"), "Day in calendar");
        private readonly IButton monthInCalendarBtn= AqualityServices.Get<IElementFactory>().GetButton(By.XPath("//button[contains(@class,'react-calendar__navigation__label')]"), "Day in calendar");
        private readonly IButton doneBtn = AqualityServices.Get<IElementFactory>().GetButton(By.XPath("//button[@data-actionable='Form.Datepicker.Continue']"), "Done");
        private IList<ILabel> listDateTitles => ElementFactory.FindElements<ILabel>(By.XPath("//div[contains(@class, '_nm44ia')]//div//div[contains(text(), ' - ')]"));


        public FilterLotoResultsPage() : base(By.XPath("//div[contains(text(), 'Filter lotto results by date')]"), "filter") { }

        public bool AreFilterResultsDisplayed()
        {
            AqualityServices.ConditionalWait.WaitForTrue(() => filterResultsLbl.State.IsDisplayed);
            return filterResultsLbl.State.IsDisplayed;
        }

        public void setFilterData()
        {
            var weekAgo = DateTime.Now.AddDays(-7).ToString("d:MMMM:yyy");

            var monthWeekAgo = DateTime.Now.AddDays(-7).ToString("MMMM");
            var dayWeekAgo = weekAgo.Substring(0, weekAgo.IndexOf(':'));

            var currentDate = DateTime.Now.ToString("d MMM yyyy");
            Assert.True(DateToBtn(currentDate).State.IsDisplayed, "Current date is displayed");
            dateFromBtn.JsActions.ClickAndWait();

            if(!monthInCalendarBtn.GetText().Contains(monthWeekAgo))
            {
                fromDateNextMonthBtn.Click();
            }
            CalendarDayBtn(dayWeekAgo).ClickAndWait();
            ClickDone();
        }

        public void ClickViewFilteredResultsButton()
        {
            viewFilteredResultsBtn.ClickAndWait();
        }

        public void ClickNextMonthForFromDate()
        {
            fromDateNextMonthBtn.ClickAndWait();
        }

        public void ClickDone()
        {
            doneBtn.Click();
        }

        public List<string> getTitles()
        {
            var titlesList = new List<string>();
            var list1 = listDateTitles;
            foreach(ILabel element in list1)
            {
                titlesList.Add(element.GetText());
            }
            return titlesList;
        }
    }
}
