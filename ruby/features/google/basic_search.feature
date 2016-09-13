@home @browser
Feature:
  When I go to the Google search page, and search for an item,
  I expect to see some reference to that item in the result summary.

  Scenario: Basic Search
    Given I am on the "GoogleHome" page
    When I search for "cats"
    Then "cat" should be mentioned in all the results
