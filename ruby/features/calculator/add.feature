@calculator
Feature: Adding numbers
  As a math nerd
  I would like the calculator to add numbers
  So that I can practice arithmetic in my head and compare with the correct result

  Background:
    Given I have a new calculator

  Scenario Outline: Add two numbers (using a scenario outline)
    When I enter "<input1>"
   And I enter "<input2>"
    And I add the numbers
    Then the result should be "<sum>"
    Examples:
    |input1  |input2  |sum|
    |40      |2       |42 |
    |1       |1       |2  |

    Scenario: Add 2 numbers
      When I enter "40"
      And I enter "2"
      And I add the numbers
      Then the result should be "42"

  Scenario: Add numbers in succession
    When I enter "2"
    And I enter "2"
    And I enter "2"
    And I add the numbers
    Then the result should be "6"

