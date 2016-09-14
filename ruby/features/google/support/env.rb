#require 'pry-byebug'
require 'page-object'
require 'rspec'

require_relative 'helpers'

World PageObject::PageFactory, Helpers

RSpec.configure do |config|
  config.expect_with :rspec do |c|
    c.syntax = [:should, :expect]
  end
end
