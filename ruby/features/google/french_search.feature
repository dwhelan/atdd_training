@web @chrome
Feature:
  When I go to the Google search page I should be able to search in French.

  Background:
    Given I am on the "GoogleHome" page
    When I change language to French

  Scenario: See page in French
    Then the search button should say "Recherche Google"

  Scenario: Search results should be in French
    Given I search for "chat"
    Then "chat" should be mentioned in all the results
