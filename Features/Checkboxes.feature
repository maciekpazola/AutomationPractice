Feature: Checkboxes

This scenario will check if checkboxes page works correctly.

@Test6
Scenario: Click on checkboxes
	When I will go to 'Checkboxes' section
	And I will check all checkboxes
	Then All checkboxes are checked
	When I will uncheck all checkboxes
	Then All checkboxes are unchecked
