using SpecFlowFirstTest.HttpRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using SpecFlowFirstTest.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace SpecFlowFirstTest.Steps
{
    [Binding]
    public class LanguageTestSteps
    {
        string en = "en";
        string es = "es";
        string bg = "bg";
        string requestBodyEn;
        string requestBodyEs;
        string requestBodyBg;

        private readonly ScenarioContext scenarioContext;

        public LanguageTestSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [When(@"I make get request to ""(.*)"" with different endpoints")]
        public void WhenIMakeGetRequestToWithDifferentEndpoints(string url)
        {
            requestBodyEn = ServiceAndLinksRequest.getServiceAndLinksRequest(url + en);
            requestBodyEs = ServiceAndLinksRequest.getServiceAndLinksRequest(url + es);
            requestBodyBg = ServiceAndLinksRequest.getServiceAndLinksRequest(url + bg);

            scenarioContext.Add("asd", requestBodyEn);
            
        }


        [When(@"I get list of countries with language code = '(en|es|bg)' and save as '(.*)'")]
        public void WhenIGetListOfCountriesWithLanguageCodeAndSaveAs(string language, string resultAlias)
        {
            var a = ServiceAndLinksRequest.getServiceAndLinksRequest("" + en);
            scenarioContext.Add(resultAlias, a);
        }

        [Then(@"SAved value '(.*)' contains '(.*)'")]
        public void ThenSAvedValueContains(string savedValueAlias, string exceptedValue)
        {
            var savedValue = scenarioContext.Get<string>(savedValueAlias);


        }



        [Then(@"Count of countries are same for all responses:")]
        public void ThenCountOfCountriesAreSameForAllResponces(List<string> list)
        {
            var values = list.Select(value => scenarioContext.Get<string>(value)).ToList();
            Assert.True(values.All(element => element == values.First()));
        }


        [Then(@"the country quantity in each request should be the same for each language")]
        public void ThenTheCountryQuantityInEachRequestShouldBeTheSameForEachLanguage()
        {

            var aaa = scenarioContext.Get<string>("asd");

            var aaaa = scenarioContext.TryGetValue("asd", out string vvv);

            string jsonEn = $@"{requestBodyEn}";
            var countriesEn = JsonConvert.DeserializeObject<CountriesRoot>(jsonEn);

            string jsonEs = $@"{requestBodyEn}";
            var countriesEs= JsonConvert.DeserializeObject<CountriesRoot>(jsonEs);

            string jsonBg = $@"{requestBodyEn}";
            var countriesBg = JsonConvert.DeserializeObject<CountriesRoot>(jsonBg);

            Assert.Equal(countriesEn.countries.Count, countriesEs.countries.Count);
            Assert.Equal(countriesBg.countries.Count, countriesEs.countries.Count);
        }
    }
}
