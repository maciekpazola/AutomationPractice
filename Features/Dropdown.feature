Feature: Dropdown

This test will check the dropdown with multiple options

@Test4
Scenario: Select all elements from droprown
	When 'Dropdown' section is opened
	And User select every option
	Then '3' options should be visible in the dropdown