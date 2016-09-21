require 'pry-byebug' if Gem::Version.new(RUBY_VERSION) >= Gem::Version.new('2.0.0')
require 'page-object'
require 'rspec'

require_relative 'helpers'

World PageObject::PageFactory, Helpers

RSpec.configure do |config|
  config.expect_with :rspec do |c|
    c.syntax = [:should, :expect]
  end
end
