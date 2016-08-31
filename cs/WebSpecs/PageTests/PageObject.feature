Feature: PageObject
	In order to write simple and maintable acceptance tests
	As a developer
	I want to use page objects

Background:
	Given I browse to the "Google Site"

@mytag
Scenario: Get title
	Then the page title should be "Google"

@ignore
Scenario: Click button
	When I click the "I'm Feeling Lucky" button

@ignore
Scenario: Click link
	When I click the "Privacy" link
	Then I should see "Welcome to the Google Privacy Policy"

