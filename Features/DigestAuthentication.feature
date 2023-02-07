Feature: DigestAuthentication

This scenarios will test another type of authentication.

@Test11
Scenario: Digest authentication happy path
	When 'Digest Authentication' section is opened
	And User login as 'Admin'
	Then User will not be logged in

	@Test12
Scenario: Digest authentication fail path
	When 'Digest Authentication' section is opened
	And User login as 'notAdmin'
	Then User will not be logged in