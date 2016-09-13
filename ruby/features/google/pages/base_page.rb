module BasePage
  HOST = 'google.ca'

  def self.included(base)
    base.extend ClassMethods
    base.send :include, PageObject
  end

  module ClassMethods
    def url(path)
      page_url "#{"https://#{HOST}"}#{path}"
    end
  end
end
