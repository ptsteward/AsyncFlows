Azure bicep deployment
==============================

## **main.bicep**
The main template to deploy a number of signalr resources in a resource group. 

## **signalr.bicep**
Configures the SignalR resource based on the provided parameters.

## **main.parameters.json**
Specifies the parameters like the environment and the number of signalr resources deployed (one to each region).
</br>
</br>
</br>
# Deployment
Deploy the template by running the below command or paste it in an Azure pipeline.

```ps
az deployment sub create -f .\main.bicep -l westus2 -p .\main.parameters.dev.json
```