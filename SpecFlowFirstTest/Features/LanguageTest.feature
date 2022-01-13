Feature: LanguageTest
	Assert countries quantity on different languages by get request

@mytag
Scenario: Assert countries quantity on different languages by get request
	When I make get request to "https://affiliate-feed.petfre.sgp.bet/1/countries?languageCode=" with different endpoints

	When I get list of countries with language code = 'en' and save as 'listFprEn'
	 And I get list of countries with language code = 'es' and save as 'listFprEs'
	 And I get list of countries with language code = 'bg' and save as 'listFprBg'


	Then SAved value 'listFprEn' contains 'asd'


	Then Count of countries are same for all responses:
	 | ResponseAlias |
	 | listFprEn     |
	 | listFprEs     |
	 | listFprBg     |


	Then the country quantity in each request should be the same for each language



