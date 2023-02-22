param location string
param resourceTags object

@description('Name of the Service Bus namespace')
param name string

@allowed(['Basic','Standard','Premium'])
@description('The messaging tier for service Bus namespace')
param sku string


resource serviceBusNamespace 'Microsoft.ServiceBus/namespaces@2022-01-01-preview' = {
  name: name
  location: location
  tags: resourceTags
  sku: {
    name: sku
  }
  properties: {
    minimumTlsVersion: '1.0'
    publicNetworkAccess: 'Enabled'
    disableLocalAuth: false
    zoneRedundant: false
  }
}
