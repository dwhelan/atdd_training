Given /^I have a new calculator$/ do
  @calculator = Calculator.new
end

When /^I add "(.*)" and "(.*)"$/ do |first, second|
  @calculator.enter(first);
  @calculator.enter(second);
  @calculator.add
end

Then /^the result should be "(.*)"$/ do |expected|
  expect(@calculator.result).to eq expected
end
