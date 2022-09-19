Feature: BasicAuth

This quick scenarios will check browser alert window authorization.

@Test2
Scenario: Authorization happy path
	When I will go to 'BasicAuth' section
	And I will login as 'admin'
	Then I will assert that I am logged in

@Test3
Scenario: Authoization fail path
	When I will go to 'BasicAuth' section
	And I will login as 'notAdmin'
	Then I will assert that I am not logged in