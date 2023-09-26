# Clean Architecture Challenges

### Map & start the solution:
0. Clone / Refetch the repo and navigate to DDDEventSourcingCQRS project
1. Deploy DDDInfrastructure.bicep using config\DDDInfrastructure.json as config. The template contains Table storage for Event Sourcing Persistence; SQL  Server and DB for Read models, and a Service Bus resource.
In the file DDDInfrastructure.json, change all [CHANGEME] with appropriate values. Then, use the following command to create the resources:

az deployment group create --resource-group  [CHANGEME] --template-file DDDInfrastructure.bicep --parameters .\config\DDDInfrastructure.json

2. Record connection strings:
- Storage account: You can find your storage account's connection strings in the Azure portal. Navigate to Security + networking > Access keys in your storage account's settings to see connection strings for  the primary key.
- SQL Server: the connection string should be like this (all the options can be found in DDDInfrastructure.json)
Server=tcp:[REPLACE_ME_WITH_SERVERNAME].database.windows.net,1433;Database=[REPLACE_ME_WITH_DATABASENAME];User ID=[REPLACE_ME_WITH_USERNAME];Password=[REPLACE_ME_WITH_PASSWORD];Trusted_Connection=False;Encrypt=True;
- Service bus: to record the connection string, navigate to the Service Bus resource in Azure Portal, open up Shared Access Policies, and click on RootManageSharedAccessKey. Then record PrimaryConnectionString.

3. Navigate to Azure SQL Server resource and add your IP address as exception to the firewall
4. Now open up DDDCQRSES project from the root of the git folder. Complete in DDDCQRSES.WEBUI\appsettings.json the connection strings recorded at point 2. Do the same for DDDCQRSEs.WebJob\appsettings.json
5. Open up terminal and run *dotnet build*
6. Now it's time to deploy the database schema
- run *dotnet tool update --global dotnet-ef*
- change directory (cd) to DDDCQRSEs.WebUI
- run *dotnet ef database update*
(This command should create some tables in your SQL database)
7. In the current terminal
- make sure you are in DDDCQRSEs.WebUI folder
- run dotnet run
(this will start the Web project.)
8. Since there is no UI, navigate to endpoint*/swagger*

Login with:
user: admin
password: P@ssw0rd

The overall diagram of Event sourcing is the following.

![image](https://user-images.githubusercontent.com/37452422/228434377-247823ba-0591-4df3-8138-898ccc2f5202.png)

[Replace with SEQUENCE DIAGRAM]

### Challenge #1: Write path
In the first challenge we will create the write path. The data will go towards the Event Store in table storage.
There is aleady some code in place. Could you localize and complete the code?

Hint #1: Create a table called EventStore in TableStorage that will serve as persistance mechanism.
ChallengeDone: Challenge is complete when the events StockAdded, StockEdited and StockDeleted can be seen in EventStore.

### Challenge #2: Read path
On the read path, data is read from projections instead of reconstitute from EventStore which is not that fast and cannot be filtered. 
The write path should publish the aggregate events on a messaging system. Then, a background process (in our case DDDCQRS.Webjob should subscribe to messages from Service Bus) and update the projections acordingly.
There is already some code in place, but you need to fill the dots in order to make it work. As first step try to make the publisher work and see that the messages are in the queue of Service Bus. Then, fix the subscriber part.

Please create a queue named StockEvents in the service bus namespace.

### Challenge #3: Versioning & Concurrency
In CQRS, since there exist a write and a read model, the syncronization between them is not done instantly. 
It can happen for example:
User A: has version of stock 1 
User B: has version of stock 1

User A and user B update the version at the same time having version 1.
One of the users should succeed, while the other should get "Data was changed by another user".

![image](https://user-images.githubusercontent.com/37452422/228435273-02659f5f-beb7-4160-9c2e-fa229a06c32c.png)


There are two places where this check is done:
1. In command validator - we should check that the version that comes from projection matches the latest version from the aggregate. If not, data was changed in the meantime.
2. In the Event Store itself while saving we get an error if duplicate keys are inserted. If we use versions as rowkey and aggregateId as partitionKey this should do the trick.

Versionings are already in place, try to implement data was changed by another user validation.

### Challenge #4: Deploy to the Cloud
Now let's deploy this to the cloud.
1. Deploy web app to an appservice. 
See the configurations that you did in CleanArchitecture in order to make it work (configuration settings and firewall rules)

2. Deploy the web job
There are two options here:
2.1 You convert the console application to a Webjob project that is deployed with the AppService 
2.2 You convert the webjob to an azure function that subscribes to the queue and processes the messages.

First one is easier :)




