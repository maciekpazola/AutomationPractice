Feature: DragAndDrop

Functionality of drag and drop

@Test6
Scenario: Drag and drop an element
	When I will go to 'Drag and Drop' section
	And I will drag and drop element A to element B
	Then I will assert element position
