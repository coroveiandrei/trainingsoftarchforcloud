# Clean Architecture Challenges

### Map & start the solution:
0. Clone / Refetch the repo and navigate to DDDEventSourcingCQRS project
1. Deploy Table Storage for Event Sourcing Persitance. Record the connection string.
2. Deploy SQL Server and DB for Read Models (create a new one than the one in CleanArchitecture). Record the connection string.
3. Deploy Service Bus for syncronization between read & write model. Record the connection string.
4. Complete in appsettings.json the connection strings for both web (DDD.CqrsEs.WebUI) and Webjob project (DDD.CqrsEs.WebJob)
5. Right click on solution and click set startup projects. Set Multiple: DDD.Cqrs.WebUI and DDD.Cqrs.WebJob.
6. Run migrations (from Package manager console, run Update-Database) 
7. Open up endpoint /swagger

Login with:
user: admin
password: P@ssw0rd

The overall diagram of Event sourcing is the following.

![image](https://user-images.githubusercontent.com/37452422/228434377-247823ba-0591-4df3-8138-898ccc2f5202.png)

Write path goes to EventStore

Read path goes to Projections in SQLserver

Syncronization is done through Service Bus.

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




