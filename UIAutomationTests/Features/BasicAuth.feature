Feature: BasicAuth

This quick scenarios will check browser alert window authorization.

@Test2
Scenario: Authentication happy path
	Given Website is opened with following browsers
	| Browsers   |
	| <Browsers> |
	When 'Basic Auth' section is opened
	And User login as 'admin'
	Then User will be logged in

	Examples: 
	| Browsers |
	| chrome   |
	| msedge   |

@Test3
Scenario: Authentication fail path
	Given Website is opened with following browsers
	| Browsers   |
	| <Browsers> |
	When 'Basic Auth' section is opened
	And User login as 'notAdmin'
	Then User will not be logged in

	Examples: 
	| Browsers |
	| chrome   |
	| msedge   |
