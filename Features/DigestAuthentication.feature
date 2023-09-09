Feature: DigestAuthentication

This scenarios will test another type of authentication.

@Test11
Scenario: Digest authentication happy path
	Given Website is opened with following browsers
	| Browsers   |
	| <Browsers> |
	When 'Digest Authentication' section is opened
	And User login as 'Admin'
	Then User will not be logged in

	Examples: 
	| Browsers |
	| chrome   |
	| msedge   |

	@Test12
Scenario: Digest authentication fail path
	Given Website is opened with following browsers
	| Browsers   |
	| <Browsers> |
	When 'Digest Authentication' section is opened
	And User login as 'notAdmin'
	Then User will not be logged in
	Examples: 

	| Browsers |
	| chrome   |
	| msedge   |