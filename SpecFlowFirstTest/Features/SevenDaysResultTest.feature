Feature: SevenDaysResultTest
	Set seven day sort

@positive
Scenario: Set seven day sort
	Given I am on the Irish loto page "https://www.oddsking.com/lotto/irish"
	And click results button
	Then Filter loto results by date is displayed

	When Filter results for last 'true' day

	When From and TO date are set
	And click View filtered results button
	Then Results are sorted by date