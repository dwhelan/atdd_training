Feature: Privacy
	In order to know what Google is doing with my day
	As a browsing dude
	I want to view Google's privacy policy

Scenario: View privacy policy
	Given I browse to the "Google Privacy Policy Page"
	Then I should see "Welcome to the Google Privacy Policy"
