# AsyncFlows - Modules

## Overview

Modules is the home to all the AsyncFlows bits and bytes you'll need to build one sweet and sassy backend C# project!

---
### Conventions
1. Package Hierarchy is expressed as an *Offset* from a *Root* using underscores
    - `_Root` Origin => `__Extensions` Next Branch
    - `____Messaging` 3rd Branch from `_Root`
        - => `_Messaging.Kafka` 1st Branch from Messaging
1. Branches originate from a single Root only
    - ✅ `___Hosting` => `____Messaging` ✅
    - 🚫`___NewPkg` <= `__Extensions` & `___Hosting`🚫
1. `global using` statements are contained within `_GlobalUsings.cs`
    - All `AsyncFlows.Modules.*` usings are global
1. All **Public ServiceCollection Registrations** fall underneath namespace
    - `AsyncFlows.Modules.Registrations`
1. All **Public Extension Methods** fall underneath namespace
    - `AsyncFlows.Modules.Extensions`
1. All **Public Constants** fall underneath namespace
    - `AsyncFlows.Modules.Constants`
___

## Package Architecture
```
📦Modules
 ┗ 📂Root
 ┃ ┗ 📂Extensions
 ┃ ┃ ┣ 📂Caching
 ┃ ┃ ┣ 📂Hosting
 ┃ ┃ ┃ ┗ 📂Messaging
 ┃ ┃ ┃ ┃ ┣ 📂Messaging.Kafka
 ┃ ┃ ┃ ┃ ┗ 📂Messaging.ServiceBus
 ┃ ┃ ┗ 📂Validation
```
---
## Build Statuses

### *Root*
[![Release](https://carvanadev.visualstudio.com/Carvana.Scheduling/_apis/build/status/Carvana.Sched.Modules/Release/_Root?branchName=master)](https://carvanadev.visualstudio.com/Carvana.Scheduling/_build/latest?definitionId=24893&branchName=master)

### *Extensions*
[![Release](https://carvanadev.visualstudio.com/Carvana.Scheduling/_apis/build/status/Carvana.Sched.Modules/Release/__Extensions?branchName=master)](https://carvanadev.visualstudio.com/Carvana.Scheduling/_build/latest?definitionId=24894&branchName=master)

### *Hosting*
[![Release](https://carvanadev.visualstudio.com/Carvana.Scheduling/_apis/build/status/Carvana.Sched.Modules/Release/___Hosting?branchName=master)](https://carvanadev.visualstudio.com/Carvana.Scheduling/_build/latest?definitionId=24895&branchName=master)

### *Messaging*
[![Release](https://carvanadev.visualstudio.com/Carvana.Scheduling/_apis/build/status/Carvana.Sched.Modules/Release/____Messaging?branchName=master)](https://carvanadev.visualstudio.com/Carvana.Scheduling/_build/latest?definitionId=24896&branchName=master)


### *Kafka Messaging*
[![Release](https://carvanadev.visualstudio.com/Carvana.Scheduling/_apis/build/status/Carvana.Sched.Modules/Release/____Messaging/_Messaging.Kafka?branchName=master)](https://carvanadev.visualstudio.com/Carvana.Scheduling/_build/latest?definitionId=24897&branchName=master)

___

## Feature Implementation
### Root
- [x] Failure Exception
- [x] Disposable Base
### Messaging
- [x] Core Messaging Abstractions
- [x] In Memory Channel Communication
- [x] Awaitable Envelope, Connecting Completion & Failure
### Kafka Messaging
- [x] Kafka Config Helpers
- [x] Kafka Sink
- [x] Kafka Source
### Servicebus Messaging
- [ ] Servicebus Config Helpers
- [ ] Servicebus Sink
- [ ] Servicebus Source
___
***ConcurrentFlows Engineering ©️2052***
