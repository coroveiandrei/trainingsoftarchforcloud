# Microservices

### Map & start the solution:
1. Clone the repo at https://github.com/edwinvw/dapr-traffic-control.
2. Make sure you have DAPR, Docker Desktop and .NET 7 SDK installed
DAPR Cli - https://docs.dapr.io/getting-started/install-dapr-cli/
Docker Desktop - https://www.docker.com/products/docker-desktop/
3. Make sure you run dapr init
4. Follow the steps from the readme of repo ( https://github.com/edwinvw/dapr-traffic-control) at point 1  from chapter "Run the application in Dapr self-hosted mode"
If you have issues with execution policy, just run:
Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass
4. If you succeed in following the steps, you should be able to see emails with fines poping at http://localhost:4000

### Chalenge #1 - Inspect State Store

1. Open up TrafficControllerService project and inspect DAPRVechicleStateRepository
* a DAPRClient is injected that has access to statestore
* via DAPRClient we access and save the state of the vehicle

2. Inspect the underlaying store. TrafficControl uses something to store state
* navigate to src/dapr/components
* could you identify what software component  it uses to store state?


### Chalenge #2 - Inspect Service Invocation

Inspect the Invoke between FineCollectionService and VehicleRegistrationService
1. In CollectionController a call is made to proxy vechicleRegistrationService.GetVehicleInfo
2. Get Vechicle info calls the Vechicle microservice using HTTP Client. It also uses the auto deserialization from Json
3. Inspect how VehicleRegistrationService is registered in container. Is it singleton, is it transient? Why? 
4. Inspect in Program.cs how the HTTPClient is created


### Challenge #3 - DAPR Pub/Sub
1. For the publisher part inspect TrafficController.VehicleExitAsync, the last lines of code of the method.
2. For the subscriber part inspect CollectionController.CollectFine
3. For the configuration part, navigate to /dapr/components/pubsub.yaml
 

### Challenge #4 - Inspect Bindings


### Challenge #5 - Inspect Monitoring


### Challenge #6 - Inspect Actors
