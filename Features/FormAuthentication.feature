Feature: FormAuthentication

This feature will test if simple authentication form works correctly.

@Test9
Scenario: Login with correct credentials
	When 'Form Authentication' section is opened
	And Correct credentials are filled in
	And Login button is clicked
	Then User is successfully logged in

@Test10
Scenario: Login with wrong credentials
	When 'Form Authentication' section is opened
	And Wrong credentials are filled in
	And Login button is clicked
	Then User is not successfully logged in