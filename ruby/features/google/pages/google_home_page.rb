require_relative 'header_section'

class GoogleHomePage
  include BasePage
  include HeaderSection

  url '/'

  text_field 'search_box', name: 'q'
  button 'search_button',  value: 'Search'
  button 'french_search_button',  value: 'Rechercher'
  button 'lucky_button',  value: "I'm Feeling Lucky"

  h3s 'result_headings', class: 'r'
  divs 'result_links', class: 'f kv _SWb'
  spans 'result_spans', class: 'st'
  link 'french_link', css: "#_eEe a"
  element 'search_btn', css: "div center input"

  def select_french
    french_link
  end

  def search_for(terms)
    self.search_box = terms
    perform_search
  end

  def perform_search
    search_button if search_button?
    french_search_button if french_search_button?
  end

  def lucky_search
    lucky_button
  end

  def results
    @results ||= begin
      wait_until { result_headings_elements.count > 0 }
      titles = result_headings_elements.map {|heading| heading.text }
      links = result_links_elements.map {|div| div.text }
      texts = result_spans_elements.map {|span| span.text }

      results = []
      titles.count.times do |i|
        results << SearchResult.new(titles[i], links[i], texts[i])
      end
      results
    end
  end
end

class SearchResult
  attr_reader :title, :link, :text

  def initialize(title, link, text)
    @title = title
    @link = link
    @text = text
  end

  def contains(term)
    title =~ /#{term}/i || link =~ /#{term}/i || text =~ /#{term}/i
  end
end
