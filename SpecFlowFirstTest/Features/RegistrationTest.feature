Feature: OddRegistrationTest
	Complete the Registration Process

@positive
Scenario: Complete the registration
	Given I am on the main page "https://www.oddsking.com/"
	And click join button
	Then registration form is displayed

	When email, username, password are entered
	 | Field         | Value             |
	 | Email Address | svarvara1@mail.ru |
	 | Username      | svarvara1         |
	 | Password      | Pp12345678-       |
	 And Conditions are accepted
	 And Click Continue button
	Then Form with personal information is displayed

	When I enter title, first name, last name, date of birth
	 | Field         | Value    |
	 | Title         | Mrs      |
	 | First Name    | Varvara  |
	 | Last Name     | Ivanova  |
	 | Date of birth | 01012000 |
	 And Click Continue button
	Then Form with contacts is displayed

	When I enter contact data
	 | Field             | Value                  |
	 | Telephone         | 11111111111            |
	 | Security Question | Make of your first car |
	 | Answer            | Test                   |
	 And Click Continue button
	Then Form with address is displayed

	When I entered address 
	 | Field           | Value                    |
	 | .buildingNumber | 33                       |
	 | .abodeNumber    | Flat 48                  |
	 | .buildingName   | Belgravia Court          |
	 | .line1          | Flat 48, Belgravia Court |
	 | .line2          | 33 Ebury Street          |
	 | .city           | London                   |
	 | .postcode       | SW1W 0NY                 |
	 And Click Continue button
	Then Settings form is displayed 

	When No marketing option is shosen in promotions
	 And Click Register button
	Then Registration is successfull