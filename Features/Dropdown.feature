Feature: Dropdown

This short scenario will check the Add/Remove Elements section 

@Test4
Scenario: Select all elements from droprown
	When I will go to 'Dropdown' section
	And I will select every option
	Then I will assert if number of options in dropdow are equal '2'