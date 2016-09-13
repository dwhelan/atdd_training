require_relative 'page_object_matcher'

module RSpec
  module Matchers
    define(:have_text) do
      include PageObjectMatcher

      match { page.text.include? expected }

      description { "#{page.class} should have text #{expected}" }

      def failure_message
        "expected '#{page.class}' to have text '#{expected}'"
      end

      def failure_message_when_negated
        "expected '#{page.class}' not to have text '#{expected}' but it does"
      end
    end
  end
end
