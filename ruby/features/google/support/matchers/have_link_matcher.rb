require_relative 'page_object_matcher'

module RSpec
  module Matchers
    define(:have_link) do
      include PageObjectMatcher

      match { element_ok? }

      def tag_name
        'a'
      end
    end
  end
end
