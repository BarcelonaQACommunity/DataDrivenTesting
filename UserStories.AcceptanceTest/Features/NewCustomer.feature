Feature: Creates a new customer


Scenario: Valid customers can be created
	Given The user enters to the home page	
	When The user logs with a valid user
	And The user goes to the new customer page
	When The user tries to create all valid customers
