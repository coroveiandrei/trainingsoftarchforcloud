param location string = resourceGroup().location


param storageAccounts array 


//Resource creation section
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
