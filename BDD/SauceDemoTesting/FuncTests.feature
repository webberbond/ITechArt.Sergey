Feature: FuncTests
	Logging in the website for using site functionality
	Adding items to cart
	Logging out
	
	Scenario: Successful Login 
		Given I go to the website saucedemo.com
		And I fill username in the placeholder
		And I fill password in the placeholder
		When I click button Login
		Then User should be logged in
		And Quite the browser
		
	Scenario: Successful adding items to cart
		Given User should be logged in
		And I click Add To Cart button
		And I see that the item was added to the shopping cart container
		And Quite the browser
		
	Scenario: Successful Logout
		Given User should be logged in
		And I click on the menu in the left corner of the site
		And I click Logout button
		And I see Login form
		And Quite the browser
		