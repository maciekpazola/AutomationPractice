﻿Feature: Checkboxes

This scenario will check if checkboxes page works correctly.

@Test6
Scenario: Click on checkboxes
	Given Website is opened with following browsers
	| Browsers   |
	| <Browsers> |
	When 'Checkboxes' section is opened
	And I will check all checkboxes
	Then All checkboxes are checked
	When I will uncheck all checkboxes
	Then All checkboxes are unchecked
	
	Examples: 
	| Browsers |
	| chrome   |
	| msedge   |