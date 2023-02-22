param location string

param resourceTags object

param servername string
param databaseName string

param username string
param password string

@allowed(['Enabled','Disabled'])
param publicNetworkAccess string = 'Enabled'

param databaseServerName string = '${servername}dbserver'

resource sqlServerResource 'Microsoft.Sql/servers@2021-11-01' ={
  name: databaseServerName
  tags: resourceTags
  location: location
  properties: {
    minimalTlsVersion: '1.2'
    publicNetworkAccess: publicNetworkAccess
    restrictOutboundNetworkAccess: 'Disabled'
    version: '12.0'
    administratorLogin: username
    administratorLoginPassword: password
  }
}

resource sqlDatabase 'Microsoft.Sql/servers/databases@2021-02-01-preview' = {
  parent: sqlServerResource
  name: databaseName
  location: location
  tags: {
    displayName: 'Database'
  }
  sku: {
    name: 'Basic'
  }
  properties: {
    collation: 'SQL_Latin1_General_CP1_CI_AS'
    maxSizeBytes: 1073741824
  }
}
