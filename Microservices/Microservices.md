# Microservices

### Map & start the solution:
1. Clone the repo at https://github.com/edwinvw/dapr-traffic-control.
2. Make sure you have DAPR, Docker Desktop, and .NET 7 SDK installed
DAPR Cli - https://docs.dapr.io/getting-started/install-dapr-cli/
Docker Desktop - https://www.docker.com/products/docker-desktop/
3. in a cmd run:  _dapr init_
4. Follow the steps from the readme of the repo starting here: https://github.com/edwinvw/dapr-traffic-control#start-the-infrastructure-components
If you have issues with the execution policy, just run:
Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass
5. If you succeed in following the steps, you should be able to see emails with fines poping at http://localhost:4000
6. If you are on Mac and you get this error, it is due to a network security issue on Mac. Please run the steps here to run the application with Consul (https://github.com/edwinvw/dapr-traffic-control#running-self-hosted-on-macos-with-antivirus-software) 

`` WARN[0275] encountered a retriable error while publishing a subscribed message to topic speedingviolations, err: retriable error returned from app while processing pub/sub event 6967c339-4aef-4b64-8658-0e0c4689598e, topic: speedingviolations, body: System.AggregateException: One or more errors occurred. (Response status code does not indicate success: 500 (Internal Server Error).)
 ---> System.Net.Http.HttpRequestException: Response status code does not indicate success: 500 (Internal Server Error).
   at System.Net.Http.HttpResponseMessage.EnsureSuccessStatusCode()
   at System.Net.Http.Json.HttpClientJsonExtensions.GetFromJsonAsyncCore[T](Task`1 taskResponse, JsonSerializerOptions options, CancellationToken cancellationToken) ``

### Challenge #1 - Inspect State Store

1. Open up TrafficControllerService project and inspect DAPRVechicleStateRepository
* a DAPRClient is injected that has access to statestore
* via DAPRClient we access and save the state of the vehicle

2. Inspect the underlying store. TrafficControl uses something to store the state
* Navigate to src/dapr/components
* could you identify what software component  it uses to store state?


### Challenge #2 - Inspect Service Invocation

Inspect the Invoke between FineCollectionService and VehicleRegistrationService
1. In CollectionController a call is made to proxy vechicleRegistrationService.GetVehicleInfo
2. Get Vechicle info calls the Vechicle microservice using HTTP Client. It also uses the auto deserialization from JSON
3. Inspect how VehicleRegistrationService is registered in the container. Is it singleton, or is it transient? Why? 
4. Inspect the Program.cs how the HTTPClient is created


### Challenge #3 - DAPR Pub/Sub
1. For the publisher part, inspect TrafficController.VehicleExitAsync, the last line of code of the method.
2. For the subscriber part, inspect CollectionController.CollectFine
3. For the configuration part, navigate to /dapr/components/pubsub.yaml
 

### Challenge #4 - Inspect Bindings


### Challenge #5 - Inspect Monitoring


### Challenge #6 - Inspect Actors
