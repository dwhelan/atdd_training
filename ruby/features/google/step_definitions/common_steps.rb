Given /^I am on the "(.+)" page$/ do |name|
  visit page_class_from_name(name)
end


Then /^Current page should have text "([^"]*)"$/ do |text|
  binding.pry
  should have_text
end
