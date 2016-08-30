Feature: PageObject
	In order to write simple and maintable acceptance tests
	As a developer
	I want to use page objects

@mytag
Scenario: Get title
	Given I browse to "http://google.com/"
	Then the page title should be "Google"
