@web @any_browser
Feature:
When I go to the Google search page, I expect to search luckily

  Scenario: Basic lucky search
    Given I am on the "GoogleHome" page
    Then I should be able to conduct a lucky search
