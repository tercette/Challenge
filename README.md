# challenge

Clone repository: https://github.com/tercette/challenge.git
In Powershell, go to the path ~challenge\ChallengeAPI\ChallengeAPI (where is located docker-compose.yaml)
In powerShell, run the command docker-compose build
In powerShell, run the command docker-compose up
![image](https://user-images.githubusercontent.com/90712354/217625700-be143202-3055-491e-9404-dc583e70c352.png)

Front-end:
	1. Start Visual Studio Code
	4. In VSC, ~challenge\contractingProject
	5. Make sure you have NodeJs v16.16.0 
	6. In VSC terminal, type: npm install to install node_modules and buid the aplication
	7. In VSC terminal, run the aplication typing: ng serve -o

Project introdution

The project start with a login page, that connect with the back end microservice and check if the user inserted contains in the database. If yes, back-end return a token and the user is allowed to enter in the application. If not, front and show a error message, clear the inputs and push user to enter with the correct credentials. For timing purposes, we set a unique user and password hardcoded in back-end. 

To connect into the application, enter this credentials:![image](https://user-images.githubusercontent.com/90712354/217627644-6d241bd7-1a4d-4b37-be56-59be9b65080f.png)

	After "LOGIN" button is clicked, the application comes live:
![image](https://user-images.githubusercontent.com/90712354/217627769-d771ce90-80ff-4fe2-923c-239a02b99304.png)

	We have other microservice here , Operations. Operations receives credit or debit and the value that use insert.
	One time the user select a type operation (Credit or Debit) and a value, a "Save" button appears. When clicked, 
	Front end sends a payload using a http call to back end, and this do some important validations and push it to
	DataBase then return the proper transation and a daily list with all transactions thas is used by the front end to 
	show the operations in the screen. 
	
	![image](https://user-images.githubusercontent.com/90712354/217627946-0e46b530-dd91-4d4a-97c8-46ae426f73a2.png)

	


