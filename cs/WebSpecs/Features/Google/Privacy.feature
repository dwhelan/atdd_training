Feature: Privacy
	In order to know what Google is doing with my day
	As a browsing dude
	I want to view Google's privacy policy

Scenario: View privacy policy
	Given I browse to the "Google Privacy Policy Page"
	Then I should see "Welcome to the Google Privacy Policy"

Scenario: Check if we can start with home page and click on terms of service
	Given I browse to the "Google Home Page"
	When I click on Privacy
	And I click on Overview
	Then I should see "Learn more about privacy and security"