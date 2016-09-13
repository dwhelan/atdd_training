require_relative 'page_object_matcher'

module RSpec
  module Matchers
    define(:have_element) do
      include PageObjectMatcher

      match { element_ok? }

      def tag_name
        nil
      end

      def tag_description
        'element'
      end
    end
  end
end
