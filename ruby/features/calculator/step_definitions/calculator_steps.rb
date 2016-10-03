Given /^I have a new calculator$/ do
  @calculator = Calculator.new
end

When(/^I enter "([^"]*)"$/) do |arg1|
  @calculator.enter(arg1);
end

When(/^I add the numbers$/) do
  @calculator.add
end

Then /^the result should be "(.*)"$/ do |expected|
  expect(@calculator.result).to eq expected
end


