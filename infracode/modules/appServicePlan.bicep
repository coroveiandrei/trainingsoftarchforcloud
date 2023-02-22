@description('Name of the hosting plan.')
param name string 

param location string 

param resourceTags object

@description('The pricing tier for the hosting plan.')
@allowed([
  'D1'
  'F1'
  'B1'
  'B2'
  'B3'
  'S1'
  'S2'
  'S3'
  'P1'
  'P2'
  'P3'
  'P1V2'
  'P2V2'
  'P3V2'
  'I1'
  'I2'
  'I3'
  'Y1'
])
param sku string

resource appServicePlan 'Microsoft.Web/serverfarms@2022-03-01' = {
  name: name
  tags: resourceTags
  location: location
  sku: {
    name: sku
  }
}

output name string = appServicePlan.name
output id string = appServicePlan.id
output sku string = appServicePlan.sku.name
