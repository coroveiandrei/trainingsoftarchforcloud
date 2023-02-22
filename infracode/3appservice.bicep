param location string = resourceGroup().location

param appServicePlans array

@description('An object array with the app services that will be instantiated')
param appServices array

param resourceTags object = {
  DeploymentType: 'Bicep'
}

module appServicePlanModules 'modules/appServicePlan.bicep' = [for appServicesConfig in appServicePlans: {
  name: '${appServicesConfig.name}-appserviceplan-module'
  scope: resourceGroup(appServicesConfig.rg)
  params: {
    location: location
    resourceTags: resourceTags
    name: appServicesConfig.name
    sku: appServicesConfig.sku
  }
}]


module appServiceModule 'modules/appService.bicep' = [ for appServiceConfig in appServices : {
  name: '${appServiceConfig.name}-appservice-module'
  dependsOn: [appServicePlanModules]
  params: {
    location: location
    appServiceName: appServiceConfig.name
    resourceTags: resourceTags
    servicePlanName: appServiceConfig.servicePlanName
    servicePlanResourceGrup: appServiceConfig.servicePlanResourceGrup == '' ? resourceGroup().name : appServiceConfig.servicePlanResourceGrup
  }
}]
