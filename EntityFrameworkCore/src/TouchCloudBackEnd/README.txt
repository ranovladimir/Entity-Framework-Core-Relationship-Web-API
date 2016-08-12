Hi, 

This is a sample project running on ASP .NET CORE, Entity Framework Core in command line, 
 with Data annotation and fluent API relationships.


 Note that SIMPLE relationships can be done just with Data annotation.
 The fluent API tooks part when you need to be more specific about your relashionships
 or when you have a bigger database.

 To interact with the Web API, you can use a Front-End project on Angular2 for example.
 For testing the Web API, you can use something like PostMan.

 Example of Postman request (of course don't forget to run the App) : 

 http://localhost:5000/v1/api/user : make a Get REQUEST to get all Users.

 http://localhost:5000/v1/api/user/2 : make a GET REQUEST to get the User with the Id number 2


  /////////////////TO SET THE COMMAND LINE//////////////////////

 Here, Entity Framework is set via command line.
 For a quick start, you can just  open a command line and run "dotnet ef database update"
 You will have a database named TouchcloudDatabase.

 For a personalize start, here is the command lines.
 First, delete the Migrations folder
 "dotnet ef migrations add <YOUR MIGRATION NAME>"
 then "dotnet ef database update"

 Note that you can modify your database name in the startup