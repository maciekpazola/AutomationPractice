Feature: ContextMenu

This short scenario will check JavaScript alert

@Test5
Scenario: Alert scenario
	When 'Context Menu' section is opened
	And I will right-click on the context menu
	Then Alert will be shown
	When I will click OK on the alert