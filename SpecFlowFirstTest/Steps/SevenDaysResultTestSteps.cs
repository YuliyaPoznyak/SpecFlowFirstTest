using Aquality.Selenium.Browsers;
using SpecFlowFirstTest.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlowFirstTest.Steps
{
    [Binding]
    public class SevenDaysResultTestSteps
    {
        private Browser browser = AqualityServices.Browser;
        private IrishLotoPage irishLotoPage = new IrishLotoPage();
        private FilterLotoResultsPage filterPage = new FilterLotoResultsPage();

        [Given(@"I am on the Irish loto page ""(.*)""")]
        public void GivenIAmOnTheIrishLotoPage(string url)
        {
            browser.Maximize();
            browser.GoTo(url);
            browser.WaitForPageToLoad();
        }
        
        [Given(@"click results button")]
        public void GivenClickResultsButton()
        {
            irishLotoPage.ClickResultsButton();
        }
        
        [When(@"From and TO date are set")]
        public void WhenFromAndTODateAreSet()
        {
            filterPage.setFilterData();
        }

        [When(@"Filter results for last '(true|false)' day")]
        public void WhenFilterResultsForLastDay(bool p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"click View filtered results button")]
        public void WhenClickViewFilteredResultsButton()
        {
            filterPage.ClickViewFilteredResultsButton();
        }
        
        [Then(@"Filter loto results by date is displayed")]
        public void ThenFilterLotoResultsByDateIsDisplayed()
        {
            filterPage.AreFilterResultsDisplayed();
        }
        
        [Then(@"Results are sorted by date")]
        public void ThenResultsAreSortedByDate()
        {
            var count = 0;
            var titlesList = filterPage.getTitles();

            var listOfDates = new List<string>();

            listOfDates.Add(DateTime.Now.ToString("dd MMM yyyy"));

            for(int i=-7; i<0; i++)
            {
                listOfDates.Add(DateTime.Now.AddDays(i).ToString("dd MMM yyyy"));
            }
            foreach (string data in listOfDates)
            {
                count += titlesList.Where(item => item.StartsWith(data)).Count();
            }



            var requiredDate = DateTime.Now.AddDays(-7);
            var areAllDatesNotOlderThanCountOfDays = titlesList.Any(date => DateTime.Compare(date, requiredDate));




            Assert.Equal(count, titlesList.Count);

        }
    }
}
