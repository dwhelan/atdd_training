Feature: PageObject
	In order to write simple and maintable acceptance tests
	As a developer
	I want to use page objects

@mytag
Scenario: Get title
	Given I browse to "http://www.google.com/"
	Then the page title should be "Google"

Scenario: Click button
	Given I browse to "http://www.google.com/"
	When I click the "I'm Feeling Lucky" button

Scenario: Click link
	Given I browse to "http://www.google.com/"
	When I click the "Privacy" link
	Then I should see "Welcome to the Google Privacy Policy"

