Before do
  @browser = browser_for ENV['DRIVER'], ENV['BROWSER']
end

After do
  @browser.close if @browser
end
