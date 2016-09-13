require_relative 'page_object'

module RSpec
  module Matchers
    module PageObjectMatcher
      include PageObject

      def failure_message
        if element?
          "expected '#{page}' '#{expected}' #{tag_description} to have a '<#{tag_name}>' tag but it has a '<#{element.tag_name}>' tag"
        else
          "expected '#{page}' to have a '#{expected}' #{tag_description}: #{element_error}"
        end
      end

      def failure_message_when_negated
        "expected '#{page}' not to have a '#{expected}' #{tag_description} but it does"
      end

      def element_ok?
        element? && tag_ok?
      end

      def tag_ok?
        tag_name.nil? || element.tag_name == tag_name
      end

      def tag_options
        default_options.merge options
      end

      def default_options
        { tag_name: nil, tag_description: 'element' }
      end

      def tag_name
        self.name.to_s.sub(/.*_/, '')
      end

      def tag_description
        self.name.to_s.sub(/.*_/, '')
      end
    end
  end
end
