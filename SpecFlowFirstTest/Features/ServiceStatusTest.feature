Feature: ServiceStatusTest
	Assert service key value

@mytag
Scenario: Make Get request
	When I make get request to url "http://affiliate-feed.petfre.sgp.bet/1/health"
	Then Service key is set to "OK" value