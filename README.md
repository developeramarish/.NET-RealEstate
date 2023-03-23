# .NET - Real Estate API
A Web API built with .NET 7, Microservices, MediatR/CQRS Pattern, EF Core, and using Clean Architecture. Data stores: PostgreSQL (Mongo?), Redis.
It can be used for listing, browsing and renting/selling properties. 


### Architecture (planned):


                  ┌────────────────────────────────────────────────────┐
                  │     API Gateway - Auth, RateLimit, LoadBalance     │        ┌──────────────┐
                  │             Cross-Cutting Concerns:                │        │External APIs:│  
          ┌───────│       Logging - ELK, Resilience, Dashboard         │──┐─────│Zillow, Stripe│
          │       └───┬───────────┬────────────┬────────────┬──────────┘  │     └──────────────┘
      ┌───┴───┐       │           │            │            │             │        
      │Clients│   ┌───┴───┐   ┌───┴───┐   ┌────┴────┐   ┌───┴─────┐   ┌───┴─────┐ 
      │ +Auth │   │Listing│   │Estates│   │Contracts│   │Utilities│   │Messaging│   ===>  Microservices
      └───┬───┘   └───┬───┘   └───┬───┘   └────┬────┘   └────┬────┘   └────┬────┘
      ┌───┴───┐   ┌───┴───┐   ┌───┴───┐    ┌───┴───┐    ┌────┴────┐   ┌────┴────┐  
      │Postgre│   │Postgre│   │Postgre│    │Postgre│    │  Mongo  │   │  Redis  │   ===>  Databases
      └───┬───┘   └───┬───┘   └───┬───┘    └───┬───┘    └────┬────┘   └────┬────┘
          │           │           │            │             │             │          
          │       ┌───┴───────────┴────────────┴─────────────┴──────┐      │
          └───────│            RabbitMQ  / MassTransit              │──────┘  
                  │          Event Bus / Transport Layer            │  Producer / Consumer
                  └─────────────────────────────────────────────────┘

####[Clients Microservice](https://github.com/ivaaak/.NET-RealEstate/tree/main/Microservices/ClientsMicroservice) - Identity, Client profiles, Roles
####[ListingsMicroservice](https://github.com/ivaaak/.NET-RealEstate/tree/main/Microservices/ListingsMicroservice) - Estate Listings, Search, Filter, Trends
####[Estates Microservice](https://github.com/ivaaak/.NET-RealEstate/tree/main/Microservices/EstatesMicroservice) - Estates Management, Data Access
####[Contracts Microservice](https://github.com/ivaaak/.NET-RealEstate/tree/main/Microservices/ContractsMicroservice) -  Contracts - Save, Modify Documents
####[UtilitiesMicroservice](https://github.com/ivaaak/.NET-RealEstate/tree/main/Microservices/UtilitiesMicroservice) - Background Tasks, File Management, Cache, Formatters
####[MessagingMicroservice](https://github.com/ivaaak/.NET-RealEstate/tree/main/Microservices/MessagingMicroservice) - Emails, Notifications 
####[External APIs](https://github.com/ivaaak/.NET-RealEstate/tree/main/Microservices/ExternalAPIsMicroservice) - Zillow API, Stripe API, Scraper


## Built With:
- [**✔**]  .NET  7 
-  [**✔**]  Microservices
-  [**✔**]  Ocelot - API Gateway
-  Camunda - Orchestration
-  [**✔**]  Auth:  .NET Identity System, Auth0, JWT 
-  [**✔**]  MediatR / CQRS Pattern
-  [**✔**]  ORM - Entity Framework Core 6
-  [**✔**]  PostgreSQL
-  [**✔**]  Redis Caching
-  Event Bus - RabbitMQ / MassTransit
-  [**✔**]  Docker - Microservices and DBs Containerization
-  [**✔**]  Fluent Validation
-  A Scraper which takes listings from real sites
-  SignalR for on-page notifications/messaging
-  [**✔**]  Sendgrid for emails
-  Cloudinary.Net for file upload/storage
-  [**✔**]  Polly - Persistance/Retries
-  [**✔**]  HangFire for task scheduling / background execution
-  Automapper
-  [**✔**]  Swagger / Swashbuckle
-  [**✔**]  Stripe Payments API
-  Algolia / Elasticsearch
-  ELK stack for logging - Elasticsearch / Logstash / Kibana

(Testing)
- MyTested.AspNetCore.Mvc 
- Moq (incl inMemory DB)
- xunit and NUnit
- coverlet / CodeCov


#### Roles :  Guest, User, Agent, Admin

Features I intend to implement:

- Auth0  (Authorization using the standard JWT middleware)
- Build/Configure a cralwer to copy listings from a real site/dataset
- SignalR for on-page notifications/messaging
- Sendgrid for emails
- Cloudinary.Net for file upload/storage
- Polly Persistance/Retries
