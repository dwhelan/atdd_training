@home @browser
Feature:
  When I go to the Google search page, and search for an item,
  I expect to see some reference to that item in the result summary.

  Scenario: Add
    Given I have a new calculator
    When I add "50" and "70"
    Then the result should be "120"
