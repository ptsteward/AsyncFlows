@description('The Azure region into which the resources should be deployed.')
param location string

@description('A signalr resource name.')
param name string

@description('A signalr resource upstream url template.')
param urltemplate string

@description('A signalr resource capacity.')
@allowed([
  1
  2
  5
  10
  20
  50
  100
])
param capacity int

@description('A signalr resource tier.')
@allowed([
  'Standard'
  'Basic'
  'Free'
  'Premium'
])
param tier string

@description('The resource tags.')
param tags object

resource signalRService 'Microsoft.SignalRService/signalR@2021-10-01' = {
  name: name
  location: location
  kind: 'SignalR' 
  sku: {
    name: tier == 'Free' ? 'Free_F1' : 'Standard_S1'
    tier: tier
    capacity: capacity
  } 
  tags: tags
  properties:{
    tls: {
      clientCertEnabled: false
    }
    networkACLs: {
      defaultAction: 'Deny'
      publicNetwork: {
        allow: [
          'ClientConnection'
          'RESTAPI'
          'ServerConnection'
          'Trace'
        ]
      }
    }
    upstream: {
      templates: [
        {
          urlTemplate: urltemplate
          hubPattern: '*'
          categoryPattern: '*'
          eventPattern: '*'
        }
      ]
    }
    features: [
      {
        flag: 'ServiceMode'
        value: 'Serverless'
      }
      {
        flag: 'EnableConnectivityLogs'
        value: 'True'
      }
      {
        flag: 'EnableLiveTrace'
        value: 'True'
      }
    ]
    cors: {
      allowedOrigins:[
        '*'
      ]
    }
  }
 }


 output signalrId string  = signalRService.id
