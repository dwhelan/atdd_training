require_relative 'page_object_matcher'

module RSpec
  module Matchers
    define(:have_div) do
      include PageObjectMatcher

      match { element_ok? }
    end
  end
end
