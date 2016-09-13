require 'rspec/matchers'

module RSpec
  module Matchers
    module PageObject
      def page
        actual.class.ancestors.include?(::PageObject) ? actual : current_page
      end

      def element(name = expected)
        page.send "#{name}_element"
      end

      def element?(name = expected)
        page.send "#{name}?"
      rescue NoMethodError
        fail NoMethodError, "There is no #{name} element defined for #{page.class}"
      end

      def element_text(name = expected)
        page.send "#{name}"
      end

      def element_error(name = expected)
        element_text(name)
      rescue => e
        message = e.message.match(/errorMessage":"([^"]+)"/)
        message ? message[1] : e.message
      end
    end
  end
end
