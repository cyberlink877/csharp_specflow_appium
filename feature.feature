Feature: TestApp

Scenario Outline: Can do series tests
	Given I am using the testapp
	When I click on color button
	Then I check for font in pink
	When I click on text button
	Then I check for the returned text
	When I click on toast button
	Then I check for the pop-up message for toast
	When I click on geolocation button
	Then I check for the search find button
	When I click on notification button
	Then I check for notification message
	When I click on speed test button
	Then I check for speed test applications