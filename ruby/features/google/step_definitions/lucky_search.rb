Then /^I should be able to conduct a lucky search$/ do
  on GoogleHomePage do |page|
    page.lucky_search
  end
end
