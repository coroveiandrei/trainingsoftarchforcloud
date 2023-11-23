# DDD CQRS Event Sourcing Architecture Challenges

### Map & start the solution:
0. Clone / Refetch the repo and navigate to DDDEventSourcingCQRS project
1. Deploy DDDInfrastructure.bicep using config\DDDInfrastructure.json as config. The template contains Table storage for Event Sourcing Persistence; SQL  Server and DB for Read models, and a Service Bus resource.
In the file DDDInfrastructure.json, change all [CHANGEME] with appropriate values. Then, use the following command to create the resources:

_az deployment group create --resource-group  [CHANGEME] --template-file DDDInfrastructure.bicep --parameters .\config\DDDInfrastructure.json_

2. Record connection strings:
- Storage account: You can find your storage account's connection strings in the Azure portal. Navigate to Security + networking > Access keys in your storage account's settings to see connection strings for  the primary key.
- SQL Server: the connection string should be like this (all the options can be found in DDDInfrastructure.json)
Server=tcp:[REPLACE_ME_WITH_SERVERNAME].database.windows.net,1433;Database=[REPLACE_ME_WITH_DATABASENAME];User ID=[REPLACE_ME_WITH_USERNAME];Password=[REPLACE_ME_WITH_PASSWORD];Trusted_Connection=False;Encrypt=True;
- Service bus: to record the connection string, navigate to the Service Bus resource in Azure Portal, open up Shared Access Policies, and click on RootManageSharedAccessKey. Then record PrimaryConnectionString.

3. Navigate to Azure SQL Server resource and add your IP address as exception to the firewall
4. Now open up DDDCQRSES project from the root of the git folder. Complete in DDDCQRSES.WEBUI\appsettings.json the connection strings recorded at point 2. Do the same for DDDCQRSEs.WebJob\appsettings.json
5. Open up terminal and run *dotnet build*
6. In the current terminal
- make sure you are in DDDCQRSEs.WebUI folder
- run dotnet run
(this will start the Web project.)
7. Since there is no UI, navigate to https://localhost:[port]/*/swagger*

Login with:
user: admin
password: P@ssw0rd

The overall sequence diagram:

![image](https://github.com/coroveiandrei/trainingsoftarchforcloud/assets/37452422/f502d235-16cf-48af-8917-fc170f909227)

### Challenge #1: Write path
In the first challenge, we will create the writing path. A new event will be generated and stored in the Event Store (Table Storage) whenever there is a web request.
There is  already some code in place.  Can you localize and complete it?

Hint: Create a table called EventStore in TableStorage that will serve as a persistence mechanism.

The challenge is complete when the events StockAdded, StockEdited, and StockDeleted are visible in EventStore.

### Challenge #2: Read path
In challenge #2, in order to optimize reads, we will read data from projections. 
In order to accomplish this task, we need to publish any events related to the aggregate onto a messaging system. Afterward, a background process (in this case, DDDCQRS.Webjob) should subscribe to messages from the Service Bus and update the projections accordingly. Though some code is already present, you will need to complete the missing parts to make sure it's done properly. As the initial step, focus on making the publisher work and verify that the messages are queued in the Service Bus. Once that is achieved, can you address the subscriber portion?

Hint: Create a queue named StockEvents in the service bus namespace.

The challenge is complete when you see the stock populated in SQL.

### Challenge #3: Versioning & Concurrency
In CQRS, since there exists a write and a read model, the synchronization between them takes time (we often call this delta t). In order not to have discrepancies, code needs to be put in place to handle potential lost updates. 
For example, both Alice and Bob may have version 1 of stock. Then, they both update the version at the same time. One of the users should succeed, while the other should get "Data was changed by another user."

![image](https://github.com/coroveiandrei/trainingsoftarchforcloud/assets/37452422/4f353a94-3213-4237-b8f1-854eba9da467)

There are two places where this check is done:
1. In the command validator - we should check that the version from the projection matches the latest version from the aggregate. If not, data was changed in the meantime.
2. In the Event Store itself, while saving, we get an error if duplicate keys are inserted. If we use the version as the row key and aggregateId as partition key this should do the trick.

Versioning is already in place; your challenge is to implement the "data was changed by another user" validation.

### Challenge #4: Deploy to the Cloud
Now, let's deploy this to the cloud.
1. Deploy web app to an appservice. 
See the configurations that you did in CleanArchitecture in order to make it work (configuration settings and firewall rules)

2. Deploy the Webjob as an Azure function

You need to create an azure function to the Stock queue and process the messages.
- Tutorial - Creating an Azure function - https://learn.microsoft.com/en-us/azure/azure-functions/create-first-function-vs-code-csharp
- Use Service Bus trigger instead of HTTP - https://learn.microsoft.com/en-us/azure/azure-functions/functions-bindings-service-bus-trigger?tabs=python-v2%2Cisolated-process%2Cnodejs-v4%2Cextensionv5&pivots=programming-language-csharp







