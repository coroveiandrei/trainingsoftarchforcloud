# Clean Architecture Challenges

### Map & start the solution:
1. Clone the repo at https://github.com/coroveiandrei/trainingsoftarchforcloud/tree/main/CleanArchitecture
2. Open up Visual Studio Community 2022 with .net core 6 installed and build the project
3. Go to Azure Portal and grab the connection string of Azure SQL DB created in the last lab. If you don't have it, you can always redeploy the template

The connection string should look like this:
Server=tcp:arcacsqlserver.database.windows.net,1433;Initial Catalog=arcacsqldb;Persist Security Info=False;User ID=andrei;Password=[CHANGEME];MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;

4. In SQL Server also make sure firewall rules are open for your ip address
5. Go to appsettings.json and replace ToDoDatabase with the connection string above
6. Right-click on CleanArc.WebUI and select Set as Startup Project
7. Open Package Manager Console and run Update-Database; this should create the database schema
 (if you work on Mac, run: dotnet tool install --global dotnet-ef and dotnet ef database update --project CleanArc.WebUI
8. From Visual Studio: Set CleanArc.WebUI as a startup project and run the project

   From VSCode: run dotnet build and then start the project (Run\StartDebugging)
10. Since there is no UI, please add /swagger in the URL; this will display the swagger page
11. Try the login endpoint with user: admin and password: P@ssw0rd
12. Try to add a new ToDo and then list it. If it succeeds, the project is fully configured 


### Chalenge #0

Inspect the project dependencies and determine where the API call lands initially and how it is handled at the business logic layer. 

### Chalenge #1 

The app's end users just reported a bug: They cannot see the description after they create a task. 
Can you see what is going on?

Hint: Scan through the project structure from controller to business logic and see where the field is not mapped

### Challenge #2
The end users want to receive an email when they add a new notification, but just in case a new field called "ShouldNotify" is sent on True. For the sake of simplicity, that field does not have to be persisted in the database and also you can just call a webhook instead of sending emails. The service INotificationService is already in place, but something is wrong. Can you spot what it is? 

Hint: To use notifications, you can inspect the events' infrastructure.

### Challenge #3
Deploy this architecture on an Azure stack and run it on Azure. What services from the ones created previously would you need?

Hint: Right-click publish from Visual Studio and either select your subscription or use the import publish profile option (profile can be downloaded from Azure)

In Azure Configuration, create a new setting: ASPNETCORE_ENVIRONMENT: DEVELOPMENT

In AppService Configuration, configure the connection string to your DB

Enable Azure services access to the database from network configuration

### Challenge #4
The customer sends you a list of todos in a CSV file in the format name description.
How could you create a background process that will import the file regularly?

Hint: Which projects do you need to reference in the new Background worker process

### Challenge #5
The customer wants to be able to support the Project functionality. A project might consist of a series of Todos. However, Todos can exist without projects. A project has a name, a start date, and an end date.
Could you help him map this new functionality?


