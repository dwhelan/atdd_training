require_relative 'page_object_matcher'

module RSpec
  module Matchers
    define(:have_text_field) do
      include PageObjectMatcher

      match { element_ok? }

      def tag_name
        'input'
      end
    end
  end
end
