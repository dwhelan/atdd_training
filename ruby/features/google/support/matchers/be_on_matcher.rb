require_relative 'page_object_matcher'

module RSpec
  module Matchers
    define(:be_on) do
      include PageObjectMatcher

      match { actual_url == expected_url }

      description { "be on #{expected} [#{expected_url}]" }

      def failure_message
        "expected to #{description}' but actually on page with url '#{actual_url}'"
      end

      def failure_message_when_negated
        "expected not to #{description}' but actually am at that url"
      end

      def actual_url
        @actual_url ||= browser.respond_to?(:url) ? browser.url : browser.current_url
      end

      def expected_url
        @expected_url ||= expected.new(page.browser).page_url_value
      end
    end
  end
end
