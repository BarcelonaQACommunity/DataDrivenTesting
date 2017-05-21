Feature: Creates a new customer

Scenario: The user can create a new customer
	Given The user enters to the home page
	And The user logs with a valid user
	When The user goes to the new customer page
	And The user creates a new customer with given email: 'xaviercasafont@hotmail.es'
	And The user clicks the submit button
	Then The new customer has been created

Scenario: The user tries to create a new customer with an existing email
	Given The user enters to the home page
	And The user logs with a valid user
	When The user goes to the new customer page
	And The user creates a new customer with a existing email
	And The user clicks the submit button
	Then The new customer cannot be created
