Feature: TSRTC
Verify The Tsrtc Home Page


Scenario Outline: Tc-01

     #Given Launch The Driver
	 And Navigate To '<URL>'
	 Then Verify Tsrtc  Should be Diplayed On The Home Page
Examples:
| URL                              |
| https://tsrtconline.in/oprs-web/ |

	 
Scenario Outline: TC-02
     And Navigate To '<URL>'
	 Then Verify Tsrtc  Should be Diplayed On The Home Page
	 Then Enter From field based on requirment '<From>' and '<FromSuggestionBox>'
	 Then Enter To Field based on requirment '<To>' and '<ToSuggestionBox>'
	 #Then Click on VajraBooking
	 Then Select Date Based on '<Date>'
	 
	
Examples:
| URL                              | From | To  | Date      | FromSuggestionBox | ToSuggestionBox |
| https://tsrtconline.in/oprs-web/ | HYDE | VIJ | 4/20/2019 | Hyderabad         | Vijayawada      |
 
 Scenario Outline: pop-1
     And Navigate To '<URL>'
	 Then Verify  Toolsqa  Should be Diplayed On The Home Page
	 #Then Click on the poup button
	 #Then Click on Alert popup
	 Then click on Ok button of the Alert
	 Then click on the prompttoup button
     
Examples:
| URL                                                                  |
| https://www.toolsqa.com/handling-alerts-using-selenium-webdriver/    |