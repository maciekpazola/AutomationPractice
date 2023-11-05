Feature: JavaScriptAlerts

That feature will have test scenarios for different type of JS alerts

@Test13
Scenario: Java script Alert
	Given Website is opened with following browsers
	| Browsers   |
	| <Browsers> |
	When 'JavaScript Alerts' section is opened
	And User click on 'jsAlert' button 
	Then Alert will be shown with text 'I am a JS Alert'
	When User will click OK on the alert
	Then Alert will disappear
	
	Examples: 
	| Browsers |
	| chrome   |
	| msedge   |

@Test14
Scenario: Java script Confirm
	Given Website is opened with following browsers
	| Browsers   |
	| <Browsers> |
	When 'JavaScript Alerts' section is opened
	And User click on 'jsConfirm' button 
	Then Alert will be shown with text 'I am a JS Confirm'
	When User will click OK on the alert
	Then Alert will disappear
	
	Examples: 
	| Browsers |
	| chrome   |
	| msedge   |

@Test15
Scenario: Java script Prompt
	Given Website is opened with following browsers
	| Browsers   |
	| <Browsers> |
	When 'JavaScript Alerts' section is opened
	And User click on 'jsPrompt' button 
	Then Alert will be shown with text 'I am a JS prompt'
	When User type message to prompt 'Test message'
	And User will click OK on the alert
	Then Alert will disappear
	
	Examples: 
	| Browsers |
	| chrome   |
	| msedge   |
