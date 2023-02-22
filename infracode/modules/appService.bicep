param location string

param resourceTags object

param appServiceName string

param servicePlanName string

param servicePlanResourceGrup string

resource appServicePlan 'Microsoft.Web/serverfarms@2022-03-01' existing = {
  name: servicePlanName
  scope: resourceGroup(servicePlanResourceGrup)
}

resource appServiceAppResource 'Microsoft.Web/sites@2022-03-01' = {
  name: appServiceName
  location: location
  tags: resourceTags
  identity: {
    type: 'SystemAssigned'
  }
  properties: {
    serverFarmId: appServicePlan.id
    httpsOnly: true
    siteConfig: {
      http20Enabled: true
      minTlsVersion: '1.2'
      ftpsState: 'Disabled'
      use32BitWorkerProcess: false
      netFrameworkVersion: 'v4.8'
      phpVersion: 'Off'
      remoteDebuggingEnabled: false
      webSocketsEnabled: true
      alwaysOn: true
      minimumElasticInstanceCount: 1
      publicNetworkAccess: 'Enabled'
    }
    publicNetworkAccess: 'Enabled'
  }
}

output id string = appServiceAppResource.id
output name string = appServiceAppResource.name

