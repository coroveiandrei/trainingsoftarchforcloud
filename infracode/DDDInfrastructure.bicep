param location string = resourceGroup().location

param sqlServers array 

param storageAccounts array 

param serviceBuses array 

param resourceTags object = {
  DeploymentType: 'Bicep'
}


module databaseServerModule 'modules/sqlDatabase.bicep' = [ for sqlServerInstance in sqlServers: {
  name: '${sqlServerInstance.name}-sqlserver-module'
  params: {
    location: location
    servername: sqlServerInstance.name
    resourceTags: resourceTags
    databaseServerName: sqlServerInstance.name
    databaseName:  sqlServerInstance.database
    username: sqlServerInstance.username
    password: sqlServerInstance.password
  }
}]

module storageModules 'modules/storageAccount.bicep' = [for storageAccount in storageAccounts: {
  name: '${storageAccount.name}-module'
  params: {
    storageAccountName: storageAccount.name
    location: location
    kind: storageAccount.kind
    tables: storageAccount.tables
    blobs: storageAccount.blobs
    skuName: storageAccount.sku.name
    publicNetworkAccess: storageAccount.properties.publicNetworkAccess
    networkAcls: storageAccount.properties.networkAcls
  }
}]

module serviceBusNamescpaceModule 'modules/serviceBus.bicep' = [ for resource in serviceBuses: {
  name: '${resource.name}-servicebus-module'
  params: {
    location: location
    name: resource.name
    resourceTags: resourceTags
    sku: resource.sku
  }
}]
