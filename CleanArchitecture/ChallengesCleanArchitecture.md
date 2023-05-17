# Clean Architecture Challenges

### Map & start the solution:
1. Clone the repo at https://github.com/coroveiandrei/trainingsoftarchforcloud/tree/main/CleanArchitecture
2. Open up Visual Studio Community 2022 with .net core 6 installed and build the project
3. Go to Azure Portal and grab the connection string of Azure SQL DB created last lab. If you don't have it, you can always redeploy the template

Connection string should look like:
Server=tcp:arcacsqlserver.database.windows.net,1433;Initial Catalog=arcacsqldb;Persist Security Info=False;User ID=andrei;Password=mypass;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;

4. In SQL Server also make sure firewall rules are open for your ip address
5. Go to appsettings.json and replace ToDoDatabase with the connection string above
6. Right click on CleanArc.WebUI and select Set as Startup Project
7. Open Package Manager Console and run Update-Database, this should create the database schema
8. (if you work on Mac, run: dotnet tool install --global dotnet-ef and dotnet ef database update --project CleanArc.WebUI
9. Set CleanArc.WebUI as startup project and run the project
10. Since there is no UI, please add /swagger in the URL, this will display the swagger page
11. Try the login endpoint with user: admin and password: P@ssw0rd
12. Try to add a new ToDo and then list it. If it succeds, the project is fully configured 


### Chalenge #0

Inspect the project dependencies and try to figure out where the api call lands initially and then how it is handled at business logic layer. You could additionaly create a small diagram with the dependencies. 

### Chalenge #1 

The end users of the app just reported a bug: They are not able to see the description after they create a task. 
Can you see what is going on?

Hint: Scan through the project structure from controller till business logic and see where the field is not mapped

### Challenge #2
The end users wants to add a validation, that if there exists an entity in the database with the name: IMPORTANT, you should not be allowed to add any other notes containing IMPORTANT in their name.
The validation message should be: "There is already an IMPORTANT note to be resolved, please resolve that one before adding a new one"

Hint: Scan through the project, find the command validator place and add a new validation

### Challenge #3
The end users want to receive an email when they add a new notification in case a new field called "Notify" is active. For the sake of simplicity we will call a webhook for notifications, instead of sending emails. The service INotificationService is already in place but there is something wrong with it. Can you spot what it is?

Hint: In order to use notifications, you can use events.

### Challenge #4
Deploy this architecture on an Azure stack and run it on Azure. What services from the ones created previously would you need?

Hint: Right click publish from Visual studio and either select your subscription, or use the import publish profile option (profile can be downloaded from Azure)

Hint2: In configuration configure ASPNETCORE_ENVIRONMENT: DEVELOPMENT

Hint3: In configuration configure the connection string to your db

Hint4: Enable Azure services access to the database from network configuration

### Challenge #5
The customer sends you a list of todos in a CSV file in the format
name, description, userName.
How could you create a background process that will import the file on a regular basis?

Hint: Which projects do you need to reference in the new Background worker process

### Challenge #6
The customer wants to be able to support the Project functionality. A project might consist of a series of Todos, however Todos can exist without projects. A project has a name, a start date and an end date.
Could you help him map this new functionality?


