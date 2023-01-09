Feature: Calculator
	Simple calculator for adding, subtracting, multiplication and division two numbers
	
	Scenario: Add two numbers
		Given I start calculator
		And I have the first number 2
		And I have the second number 3
		When I want to sum these numbers
		Then the result should be 5
		
	Scenario: Add two negative numbers
		Given I start calculator
		And I have the first number -1
		And I have the second number -4
		When I want to sum these numbers
		Then the result should be -5
		
	Scenario: Subtract two numbers
		Given I start calculator
		And I have the first number 7
		And I have the second number 5
		When I want to subtract these numbers
		Then the result should be 2
		
	Scenario: Subtract two negative numbers
		Given I start calculator
		And I have the first number -7
		And I have the second number -5
		When I want to subtract these numbers
		Then the result should be -2
		
	Scenario: Multiplication of two numbers
		Given I start calculator
		And I have the first number 4
		And I have the second number 4
		When I want to make multiplication of these numbers
		Then the result should be 16
		
	Scenario: Multiplication of two negative numbers
		Given I start calculator
		And I have the first number -1
		And I have the second number -10
		When I want to make multiplication of these numbers
		Then the result should be 10
		
	Scenario: Multiplication of two long numbers
		Given I start calculator
		And I have the first number 12111211
		And I have the second number 31211311
		When I want to make multiplication of these numbers
		Then the result should be 378006773107621
		
	Scenario: Division of two numbers
		Given I start calculator
		And I have the first number 10
		And I have the second number 5
		When I want to make division of these numbers
		Then the result should be 2
		
	Scenario: Division of two negative numbers
		Given I start calculator
		And I have the first number -15
		And I have the second number -3
		When I want to make division of these numbers
		Then the result should be 5
		
	Scenario: Division of two long numbers
		Given I start calculator
		And I have the first number 22222222
		And I have the second number 11111111
		When I want to make division of these numbers
		Then the result should be 2