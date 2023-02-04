Feature: BasicAuth

This quick scenarios will check browser alert window authorization.

@Test2
Scenario: Authentication happy path
	When 'Basic Auth' section is opened
	And User login as 'admin'
	Then User will be logged in

@Test3
Scenario: Authentication fail path
	When 'Basic Auth' section is opened
	And User login as 'notAdmin'
	Then User will not be logged in