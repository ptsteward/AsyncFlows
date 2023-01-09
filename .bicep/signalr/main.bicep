targetScope = 'subscription'

@description('The Azure region into which the resource group should be deployed.')
param location string = deployment().location

@description('Name of my stuff.')
@maxLength(35)
param myName string

@description('The deployment environment name.')
@maxLength(35)
param deploymentEnv string

@description('''The array containing the signalr resources options. 
The number of elements of this array will determine the number of signalr resources created.''')
param signalrResourceOptions array

var tags = {
  'Architecture': 'SignalR'
  'Environment': deploymentEnv
}

resource resourceGroup 'Microsoft.Resources/resourceGroups@2021-04-01' = {
  name: '${myName}-${deploymentEnv}-rg'
  location: location
  tags: tags
}

module signalRDeploy 'signalr.bicep' = [for op in signalrResourceOptions: {
  name: '${myName}-signalr-${op.region}-deploy'
  scope: resourceGroup
  params:{
    location: op.region
    name: '${myName}-signalr-${op.region}-${deploymentEnv}'
    capacity: op.capacity
    tier: op.tier
    urltemplate: op.upstreamUrlTemplate
    tags: tags
  }  
}]
