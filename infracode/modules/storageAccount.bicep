@description('Location for the storage account.')
param location string

param tables array = []

param blobs array = []

param publicNetworkAccess string = 'Enabled'

param storageAccountName string = ''

param networkAcls object = {}

param deleteRetentionPolicy object = {}

param containerDeleteRetentionPolicy object = {}

@description('Storage Account type')
@allowed([
  'Premium_LRS'
  'Premium_ZRS'
  'Standard_GRS'
  'Standard_GZRS'
  'Standard_LRS'
  'Standard_RAGRS'
  'Standard_RAGZRS'
  'Standard_ZRS'
])
param skuName string = 'Standard_RAGRS'

@allowed(['StorageV2', 'Storage', 'BlobStorage'])
param kind string = 'StorageV2'

resource storageAccountResource 'Microsoft.Storage/storageAccounts@2022-05-01' = {
  name: storageAccountName
  location: location
  kind: kind
  sku: {
    name: skuName
  }
  properties: {
    accessTier: kind == 'StorageV2' ? 'Hot' : null
    publicNetworkAccess: publicNetworkAccess
    allowBlobPublicAccess: publicNetworkAccess == 'Enabled' ? true : false
    allowCrossTenantReplication: true
    allowSharedKeyAccess: true
    minimumTlsVersion: 'TLS1_2'
    supportsHttpsTrafficOnly: true
    networkAcls: networkAcls
  }
}


resource tableServiceResoucrce 'Microsoft.Storage/storageAccounts/tableServices@2022-05-01' = if (tables != []){
  name: 'default'
  parent: storageAccountResource
}


resource tableResource 'Microsoft.Storage/storageAccounts/tableServices/tables@2022-05-01' =  [for tablename in tables : {
  name: tablename
  parent: tableServiceResoucrce
}]

resource blobServicesResource 'Microsoft.Storage/storageAccounts/blobServices@2022-05-01' =  if (blobs != []) {
  name: 'default'
  parent: storageAccountResource
  properties: {
    deleteRetentionPolicy: deleteRetentionPolicy
    containerDeleteRetentionPolicy: containerDeleteRetentionPolicy
  }
}

resource blobResource 'Microsoft.Storage/storageAccounts/blobServices/containers@2022-05-01' = [for blob in blobs : {
  name: blob
  parent: blobServicesResource
  properties: {
    denyEncryptionScopeOverride: false
    publicAccess: 'None'
    defaultEncryptionScope: '$account-encryption-key'
  }
}]

output storageAccountId string = storageAccountResource.id
output storageAccountName string = storageAccountResource.name
output storageAccountKind string = storageAccountResource.kind
