module Helpers
  def browser_for(driver_name, browser_name)
    browser = browser_name ? browser_name.to_sym : :phantomjs

    args = [
        # '--ignore-ssl-errors=true',
        # '--web-security=false'
        # '--webdriver-logfile=phantomjs.log',
        # --webdriver-loglevel=INFO',       # WebDriver Logging Level: (supported: 'ERROR', 'WARN', 'INFO', 'DEBUG') (default 'INFO') (NOTE: needs '--webdriver')
    ]

    options = {}

    if browser == :phantomjs
      # Set user agent to chrome to get reasonable responses from web sites
      capabilities = Selenium::WebDriver::Remote::Capabilities.phantomjs('phantomjs.page.settings.userAgent' => 'Mozilla/5.0 (Macintosh; Intel Mac OS X 10_11_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.116 Safari/537.36')
      options[:desired_capabilities] = capabilities
    end

    case driver_name
    when 'selenium'
      Selenium::WebDriver.for browser, options
    when 'watir', nil
      Watir::Browser.new browser, options
    else
      fail "Unsupported web driver #{driver_name}"
    end
  end

  def current_page
    @current_page
  end

  def browser
    @any_browser
  end

  def page_class_from_name(name)
    page_class_name = "#{name.delete(' ')}Page"
    Object.const_get page_class_name
  end

  def wait_for_text(text, timeout = ::PageObject.default_element_wait)
    current_page.wait_until(timeout, "Could not find text '#{text}' on the #{current_page.class}\n#{current_page.text}") do
      current_page.text.include? text
    end
  end
end
