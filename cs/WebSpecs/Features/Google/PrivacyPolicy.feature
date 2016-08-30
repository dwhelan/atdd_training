Feature: Privacy Policies
	In order to ensure my privacy is protected
	As a browser dude
	I want to use see privacy policy information

Scenario: Privacy
	Given I browse to "http://www.google.com/intl/en/policies/privacy/"
	Then I should see "Welcome to the Google Privacy Policy"

