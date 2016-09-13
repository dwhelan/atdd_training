When /^I search for "([^"]*)"$/ do |terms|
  on GoogleHomePage do |page|
    page.search_for terms
  end
end

Then /^"([^"]*)" should be mentioned in all the results/ do |search_term|
  on GoogleHomePage do |page|
    page.results.each do |result|
      expect(result.contains(search_term)).to be_truthy
    end
  end
end

When /^I change language to French$/ do
  on GoogleHomePage do |page|
    page.select_french
  end
end

Then /^the search button should say "([^"]*)"$/  do |name|
  on GoogleHomePage do |page|
    page.search_btn_element.attribute("value").should eq name
  end
end
