Feature: AddAndRemoveElements

This short scenario will check the Add/Remove Elements section 

@Test1
Scenario: Add and remove elements
	Given Website is opened with following browsers
	| Browsers   |
	| <Browsers> |
	When 'Add/Remove Elements' section is opened
	And Element is added
	And Element is added
	And All elements are removed

	Examples: 
	| Browsers |
	| chrome   |
	| msedge   |