@calculator
Feature: Adding numbers
  As a math nerd
  I would like the calculator to add numbers
  So that I can practice arithmetic in my head and compare with the correct result

  Scenario: Add two numbers
    Given I have a new calculator
    When I add "40" and "2"
    Then the result should be "42"

  @wip
  Scenario Outline: Add two numbers (using a scenario outline)
    Given I have a new calculator
    When ...

  @wip
  Scenario: Add two numbers (split up the add step into two separate steps)
    Given I have a new calculator
    When ...
    Then the result should be "42"

  @wip
  Scenario: Add numbers in succession
    When ...



