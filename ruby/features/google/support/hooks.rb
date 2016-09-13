Before '@web' do
  @browser = browser_for ENV['DRIVER'], ENV['BROWSER']
end

After '@web' do
  @browser.close if @browser
end
