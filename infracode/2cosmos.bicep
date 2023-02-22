param location string = resourceGroup().location

param cosmosServers array 

module cosmosDbModule 'modules/cosmos.bicep'= [for cosmosServer in cosmosServers: {
  name: '${cosmosServer.name}-cosmos-module'
  params: {
    cosmosDbName: cosmosServer.name
    location: location
  }
}]
