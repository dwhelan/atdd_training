Feature: PageObject
	In order to write simple and maintable acceptance tests
	As a developer
	I want to use page objects

Background:
	Given I browse to the "Google Home Page"

Scenario: Get title
	Then the page title should be "Google"

Scenario: See text
	Then I should see "Google"

Scenario: Click links
	When I click on Privacy
	Then I should see "Welcome to the Google Privacy Policy"

Scenario: Click buttons
	When I click the "I'm Feeling Lucky" button
	Then I should see "Doodles"
	
Scenario: Enter and retrieve text
	When I search for "Coypu"
	Then the search entry should be "Coypu"
	And I should see "semiaquatic rodent"
