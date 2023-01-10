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
		Given I go to the website saucedemo.com
		And I fill username in the placeholder
		And I fill password in the placeholder
		When I click button Login
		Then User should be logged in
		And I click Add To Cart button
		And I see that the item was added to the shopping cart container
		And Quite the browser
		
	Scenario: Successful adding and removing items from cart
		Given I go to the website saucedemo.com
		And I fill username in the placeholder
		And I fill password in the placeholder
		When I click button Login
		Then User should be logged in
		And I click Add To Cart button
		And I see that the item was added to the shopping cart container
		And I click Remove button
		And I see that the item was removed from the shopping cart container
		And Quite the browser
		