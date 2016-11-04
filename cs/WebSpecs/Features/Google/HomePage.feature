Feature: Home Page
	In order to search the web easily
	As a browsing dude
	I want to search for stuff

Background:
	Given I browse to the "Google Home Page"

Scenario: The open the box experience should be warm and inviting
	Then the page title should be "Google"
	And I should see "Google"
		
Scenario: Basic search
	When I search for "Coypu"
	Then I should see "semiaquatic rodent"

Scenario: View privacy policy
	When I select Privacy
	Then I should be on the "Privacy Policy Page"

Scenario: I'm feeling lucky search
	When I select "I'm Feeling Lucky"
	Then I should see "Doodles"
