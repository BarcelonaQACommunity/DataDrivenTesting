Feature: Creates a new account

#TO DO: Complete steps Exercise 2
Scenario Outline: The user can creates a new account
    Given The user enters to the home page
    And The user logs with a valid user
    When The user goes to the new account page
    And The user creates a new account with parameters '<customerId>', '<accountType>', '<initialDeposit>'
	Then The new account has been created

    Examples: 
    | customerId | accountType | initialDeposit |
    | 72218      | Current     | 500            |
    | 72218      | Savings     | 500            |