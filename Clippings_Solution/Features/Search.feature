Feature: Filtering by Min and Max value

Scenario: Filter by min and max value with input fields is successful
	Given I navigate to the search page
	And I change currency to "euro"
	When I enter "100" in the min value input
	And I enter "300" in the max value input
	And I select the search button
	Then the page should display filtered results