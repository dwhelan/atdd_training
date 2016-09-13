@calculator
Feature:
  When I go to the Google search page, and search for an item,
  I expect to see some reference to that item in the result summary.

  Scenario: Add two numbers
    Given I have a new calculator
    When I add "50" and "70"
    Then the result should be "120"


  Scenario Outline: Add two numbers (using a scenario outline)
    Given I have a new calculator
    When I add "<first>" and "<second>"
    Then the result should be "<expected>"

    Examples:
      |first |second |expected|
      |50    |70     |120     |
      |1     |-1     |0       |

  @wip
  Scenario Outline: Add multiple numbers
    Given I have a new calculator
    When I add <numbers>
    Then the result should be <expected>
    Examples:
      |numbers|expected |
      |1,2    |3        |
      |1,2,3  |6        |



