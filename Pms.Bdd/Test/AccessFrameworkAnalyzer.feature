Feature: AccessFrameworkAnalyzer
	In order to avoid paid searches and applications

@AccessFrameworkAnalyzer 
Scenario: User with free membership already maxed searches and application
	Given the membership types
 | MembershipTypeName | MaxSearchesPerDay | MaxApplicationsPerDay |
 | Free               | 5                 | 1                     |
 | Siler              | 10                | 10                    |
 | Gold               | 15                | 15                    |
 | Platinum           | 50                | 50                    |
 And a user
 | ID | Username | FirstName | LastName | MembershipTypeName | CurrentSearchesCount | CurrentApplicationsCount |
 | 10 | Drakem   | Sanjay    | Gupta    | Free               | 5                    | 1                        |
	When Access Result is Required
 Then then result should be
 | CanSearch | CanApply |
 | false     | false    |
