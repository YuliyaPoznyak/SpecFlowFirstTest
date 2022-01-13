using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SpecFlowFirstTest.HttpRequests;
using SpecFlowFirstTest.Models;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlowFirstTest.Steps
{
    [Binding]
    public class ServiceStatusTestSteps
    {
        string requestBody;

        [When(@"I make get request to url ""(.*)""")]
        public void WhenIMakeGetRequestToUrl(string url)
        {
            requestBody = ServiceAndLinksRequest.getServiceAndLinksRequest(url);
        }
        
        [Then(@"Service key is set to ""(.*)"" value")]
        public void ThenServiceKeyIsSetToOkValue(string expectedValue)
        {
            /* Without using models
            dynamic json1 = JObject.Parse(requestBody);
            string serviceData = json1.service;

            Assert.Equal(expectedValue, serviceData);
            */

            string json = $@"{requestBody}";
            var serviceLinks = JsonConvert.DeserializeObject<ServiceLinks>(json);

            Assert.Equal(expectedValue, serviceLinks.service);
        }
    }
}
