# Microservices

### Map & start the solution:
1. Clone the repo at https://github.com/edwinvw/dapr-traffic-control. Use branch demo/updateconf
git clone https://github.com/edwinvw/dapr-traffic-control
2. Make sure you have DAPR, Docker Desktop and .NET 7 SDK installed
DAPR Cli - https://docs.dapr.io/getting-started/install-dapr-cli/
Docker Desktop - https://www.docker.com/products/docker-desktop/
3. Follow the steps from the readme of repo at point 1 from chapter "Run the application in Dapr self-hosted mode"
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

