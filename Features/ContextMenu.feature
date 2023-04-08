Feature: ContextMenu

This short scenario will check JavaScript alert

@Test5
Scenario: Alert scenario
	When 'Context Menu' section is opened
	And User right click on the context menu
	Then Alert will be shown with text 'You selected a context menu'
	When User will click OK on the alert
	Then Alert will disappear