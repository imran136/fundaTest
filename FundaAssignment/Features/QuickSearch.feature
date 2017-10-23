Feature: QuickSearch on home page
	In order to complete the assignment
	As a candidate
	I want to write some UI/Acceptance test

@UI
Scenario Outline: As an user I can make a quick search for each category
	Given I am on the home page	
	And '<Category>' is selected
	When I do a search
	Then result page is shown	
	And I can see '<Search-Result>'
Examples: 
	| Category  | Search-Result      |
	| Koop      | koopwoningen       |
	| Huur      | huurwoningen       |
	| Nieuwbouw | nieuwbouwprojecten |
	| recreatie | recreatiewoningen  |
	| europe    | europese           |

