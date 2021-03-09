## *****Vacation-Destination.com Hotel*****
Hello all who decided to use our app to help book their next destination for an unforgettable vacation. Using our platform makes booking a breeze while giving you everything you need to know about your selection, and the ability to let other users know which places are a must to go to. Finally enjoy our exclusive benefits and special surprises with our vacation packages through our partnerships.

## Using The Application

 - Booking
	 - Browse through our selection of available destinations and accompanying hotels and their amenities.
	 - Depending on where you are booking from you may be asked if you with to add a flight or car rental for your trip.
 - Leaving a review
	 - After enjoying your trip you may be inclined to review the various parts included and you can! Simply view your transaction to find your hotel, package, transportation details, etc. You will notice a spot to leave your review once you do this.
	 
 - As A User (VS/Postman)
	 - Once the application is on your local machine you should be able to run it in Visual Studio which will open a browser to display the running server and its associated parts.
	 - After the webpage loads and no errors are seen you can open Postman to start interacting with the information already in the application or add you own.
		 - To do this you must copy the web address from the browser window that opened up and use the /api/Hotel, /api/Review, /api/Transaction, /api/Customer, or /api/VacPac after the web address to modify or create an entry in each respective table. (ex https://localhost:XXXXX/api/Hotel)
			 - Following that you can select either:
				 - GET (Views already created data)
				 - POST (Creates new data)
				 - PUT (Edits data)
				 - DELETE (Removes data)
**To target specific entries you must input the corresponding ID for the selected information** 
-ex  https://localhost:XXXXX/api/Hotel/(id)

- How To Use Console Application
	- In Visual Studio, right click on "Solution 'BlueBadgeFinalProject'" and click on "Properties."
	- Check option for "Multiple startup projects". Change options for BlueBadgeFinalProject.WebAPI and BlueBadgeFinalProject.Console to Start. Click OK.
	- Get Authorization token from Postman (POST https://localhost:XXXXX/token). Go to "BlueBadgeFinalProject_Console" and click on "CustomerAPI" class. Copy token and paste 	  at the top of the page next to "private string AuthorizationKey =" (It should look like this: private string AuthorizationKey = "enter token here";).
	- Follow the token instructions above for "HotelAPI", "JunctionAPI", "ProgramUI", "ReviewAPI", "TransactionAPI", and "VacationPackageAPI." 
	- Click Start at the top of the page in Visual Studio and follow instructions in the console. It currently has the options to display all data and delete hotels from    		database. 
	
> Super Fixers [EFA Help Queue](https://efahelpqueue.azurewebsites.net/Login).

> Help from: 
> -https://docs.google.com/document/d/1Op7j_IquVbA_HVvAezdcjxJbHDtimHq7ugNtx4ojC1I/edit.
 
> -[Stack Overflow](https://stackoverflow.com/).

> -https://www.c-sharpcorner.com/article/creating-web-api-and-consuming-in-console-application-using-web-client-in-a-sync/.

> -https://www.youtube.com/watch?v=qm29vYcYBeg.

> -https://www.youtube.com/watch?v=YoQE3_iUXgk.
 
> -https://www.youtube.com/watch?v=Ry45EkZQ2CM.
 
>https://gist.github.com/ZacharyPatten/798ed612d692a560bdd529367b6a7dbd.

>Eleven Note API Walkthrough https://elevenfifty.instructure.com/courses/517/modules 

> Written with [StackEdit](https://stackedit.io/).
 
> Tool teams of developers:https://trello.com/b/mC5ytQ3G/net-blue-badge-project.

>Technologies:

 .Net Framework C#

 PostMan

 Trello

 GoogleDocs\

>Launch:

 Visual Studio Community 2019 

 Microsoft .Net Framework
 
 Help Page API End Point Documentation:

![DataTabales](/Images/snipp1.PNG)
![DataTabales](/Images/snipp2.PNG)
![DataTabales](/Images/snipp3.PNG)
