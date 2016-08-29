Feature: Addition
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

	Background: Create a new calculator
	Given I have a new calculator

Scenario Outline: Add two numbers
	Then adding <first> and <second> should create the correct <sum>.

	Examples:
		| first | second | sum |
		| 50    | 70     | 120 |
		| 1     | 2      | 3   |
