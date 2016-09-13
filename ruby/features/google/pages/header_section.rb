module HeaderSection
  include PageObject

  link    'full_user_name_link', id:  'gsft_full_name'
  button   'logout',             css: 'button.nav_header_button:nth-child(1)'

  def full_user_name
    full_user_name_link_element.text
  end
end
