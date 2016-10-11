class Calculator

  def initialize
    self.entries = []
    self.result = 0
  end

  def enter number
    entries << number.to_i
  end

  def add
    self.result = (entries.pop + entries.pop).to_s
  end

  attr_reader :result

  private

  attr_accessor :entries
  attr_writer :result
end
