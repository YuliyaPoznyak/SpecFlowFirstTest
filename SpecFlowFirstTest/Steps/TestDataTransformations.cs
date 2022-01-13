using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SpecFlowFirstTest.Steps
{
    [Binding]
    public class TestDataTransformations
    {
        [StepArgumentTransformation("(.*)")]
        public List<string> WithList(Table table)
        {
            return table.Rows.Select(row => row[0]).ToList();
        }

        [StepArgumentTransformation("(.*)")]
        public Dictionary<string, string> WithDictionary(Table table)
        {
            return table.Rows.ToDictionary(key => key[0], value => value[1]);
        }

        [StepArgumentTransformation("(contain|not contain)")]
        [StepArgumentTransformation("(equal|not equal)")]
        [StepArgumentTransformation("(opened|not opened)")]
        [StepArgumentTransformation("(displayed|not displayed)")]
        public bool WithBoolean(string value)
        {
            return !value.Contains("not");
        }

        [StepArgumentTransformation("(enable|disable)")]
        public bool WithEnabled(string value)
        {
            return value.Contains("enable");
        }

        [StepArgumentTransformation("(check|uncheck)")]
        public bool GetState(string value)
        {
            return value.Equals("check");
        }

        [StepArgumentTransformation("(suspend|unsuspend)")]
        public bool WithBooleanFromSuspending(string value)
        {
            return !value.Contains("un");
        }
    }
}
