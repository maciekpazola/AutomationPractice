Feature: Dropdown

This test will check the dropdown with multiple options

@Test4
Scenario: Select all elements from droprown
	When I will go to 'Dropdown' section
	And I will select every option
	Then I will assert if number of options in dropdow are equal '3'