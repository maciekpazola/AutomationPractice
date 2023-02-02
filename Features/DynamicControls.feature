Feature: DynamicControls

Controls present on the page are dynamic. Feature contrain scenario foreach control.
First one for checkbox that is can be removed and added.
Second one is form that is disabled when site is loaded, after clicking button it will change state.

@Test7
Scenario: Remove and add checkbox
	When I will go to 'Dynamic Controls' section
	And I will check all checkboxes
	Then All checkboxes are checked
	When I will remove checkbox
	Then Checkbox will gone
	When I will add checkbox
	Then Checkbox will appear