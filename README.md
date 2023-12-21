
# TT-ECommerce

**TT-ECommerce** is a fictional eCommerce, built with .Net Core and different software architecture and technologies like Microservices Architecture, Vertical Slice Architecture, CQRS Pattern, Domain Driven Design (DDD), Event Driven Architecture. For communication between independent services, we use asynchronous messaging with using rabbitmq on top of MassTransit library, and sometimes we use synchronous communication for real-time communications with using REST and gRPC calls.

## Acknowledgements

 - Using [Microservices]() and [Vertical Slice Architecture]() as a high level architecture
 - Using [Event Driven Architecture]() on top of RabbitMQ Message Broker and MassTransit library
 - Using [Domain Driven Design]() in most of services like Customers, Catalogs, ...
 - Using [Event Sourcing]() and [EventStoreDB]() in [Audit Based]() services like Orders, Payment
 - Using [Data Centeric Architecture]() based on [CRUD]() in Identity Service
 - Using [CQRS Pattern]() on top of [MediatR]() library and spliting [read models]() and [write models]()
 - Uing [Structured logging]() with serilog and exporting logs to [Elastic Seacrch]() and [Kibana]() through [serilog-sinks-elasticsearch](https://github.com/serilog-contrib/serilog-sinks-elasticsearch) sink
 - Using [Outbox Pattern]() for all microservices for [Guaranteed Delivery](https://www.enterpriseintegrationpatterns.com/GuaranteedMessaging.html) or [At-least-once Delivery](https://www.cloudcomputingpatterns.org/at_least_once_delivery/)
 - Using [Inbox Pattern]() for handling [Idempotency](https://www.cloudcomputingpatterns.org/idempotent_processor/) in reciver side and [Exactly-once Delivery](https://www.cloudcomputingpatterns.org/exactly_once_delivery/)
 - Using [UnitTests]() and [NSubstitute]() for mocking dependencies
 - Using [Integration Tests]() and [End To End Tests]() on top of [testcontainers-dotnet](https://github.com/testcontainers/testcontainers-dotnet) library for cleanup our test enviroment through docker containers
 - Using [Minimal APIs]() for handling requests
 - Using [Fluent Validation]() and a [Validation Pipeline Behaviour](./src/BuildingBlocks/BuildingBlocks.Validation/RequestValidationBehavior.cs) on top of MediatR
 - Using [Postgres]() for write database as relational DB and [MongoDB]() and [Elasric Search]() for read database
 - Using docker and [docker-compose]() for deployment
 - Using [Microsoft Tye](https://github.com/dotnet/tye) for deployment
 - Using [YARP](https://microsoft.github.io/reverse-proxy/) reverse proxy as API Gateway
 - Using different type of tests like [Unit Tests](), [Integration Tests](), [End-To-End Tests]() and [testcontainers](https://microsoft.github.io/reverse-proxy/) for testing in isolation

## Technologies - Libraries

- [.NET 7](https://dotnet.microsoft.com/download) - .NET Framework and .NET Core, including ASP.NET and ASP.NET Core
- [MassTransit](https://github.com/MassTransit/MassTransit) - Distributed Application Framework for .NET
- [StackExchange.Redis](https://github.com/StackExchange/StackExchange.Redis) - General purpose redis client
- [Npgsql Entity Framework Core Provider](https://www.npgsql.org/efcore/) - Npgsql has an Entity Framework (EF) Core provider. It behaves like other EF Core providers (e.g. SQL Server), so the general EF Core docs apply here as well
- [EventStore-Client-Dotnet](https://github.com/EventStore/EventStore-Client-Dotnet) - Dotnet Client SDK for the Event Store gRPC Client API written in C#
- [FluentValidation](https://github.com/FluentValidation/FluentValidation) - Popular .NET validation library for building strongly-typed validation rules
- [Swagger & Swagger UI](https://github.com/domaindrivendev/Swashbuckle.AspNetCore) - Swagger tools for documenting API's built on ASP.NET Core
- [Serilog](https://github.com/serilog/serilog) - Simple .NET logging with fully-structured events
- [Polly](https://github.com/App-vNext/Polly) - Polly is a .NET resilience and transient-fault-handling library that allows developers to express policies such as Retry, Circuit Breaker, Timeout, Bulkhead Isolation, and Fallback in a fluent and thread-safe manner
- [Scrutor](https://github.com/khellang/Scrutor) - Assembly scanning and decoration extensions for Microsoft.Extensions.DependencyInjection
- [Opentelemetry-dotnet](https://github.com/open-telemetry/opentelemetry-dotnet) - The OpenTelemetry .NET Client
- [DuendeSoftware IdentityServer](https://github.com/DuendeSoftware/IdentityServer) - The most flexible and standards-compliant OpenID Connect and OAuth 2.x framework for ASP.NET Core
- [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json) - Json.NET is a popular high-performance JSON framework for .NET
- [Rabbitmq-dotnet-client](https://github.com/rabbitmq/rabbitmq-dotnet-client) - RabbitMQ .NET client for .NET Standard 2.0+ and .NET 4.6.1+
- [AspNetCore.Diagnostics.HealthChecks](https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks) - Enterprise HealthChecks for ASP.NET Core Diagnostics Package
- [Microsoft.AspNetCore.Authentication.JwtBearer](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer) - Handling Jwt Authentication and authorization in .Net Core
- [NSubstitute](https://github.com/nsubstitute/NSubstitute) - A friendly substitute for .NET mocking libraries.
- [StyleCopAnalyzers](https://github.com/DotNetAnalyzers/StyleCopAnalyzers) - An implementation of StyleCop rules using the .NET Compiler Platform
- [AutoMapper](https://github.com/AutoMapper/AutoMapper) - Convention-based object-object mapper in .NET.
- [Hellang.Middleware.ProblemDetails](https://github.com/khellang/Middleware/tree/master/src/ProblemDetails) - A middleware for handling exception in .Net Core
- [IdGen](https://github.com/RobThree/IdGen) - Twitter Snowflake-alike ID generator for .Net

## Technologies - Libraries

The bellow architecture shows that there is one public API (API Gateway) which is accessible for the clients and this is done via HTTP request/response. The API gateway then routes the HTTP request to the corresponding microservice. The HTTP request is received by the microservice that hosts its own REST API. Each microservice is running within its own AppDomain and has directly access to its own dependencies such as databases, files, local transaction, etc. All these dependencies are only accessible for that microservice and not to the outside world. In fact microservices are decoupled from each other and are autonomous. This also means that the microservice does not rely on other parts in the system and can run independently of other services.

## Application Structure

In this project I used [vertical slice architecture](https://jimmybogard.com/vertical-slice-architecture/) or [Restructuring to a Vertical Slice Architecture](https://codeopinion.com/restructuring-to-a-vertical-slice-architecture/) also I used [feature folder structure](http://www.kamilgrzybek.com/design/feature-folders/) in this project.

- We treat each request as a distinct use case or slice, encapsulating and grouping all concerns from front-end to back.
- When We adding or changing a feature in an application in n-tire architecture, we are typically touching many different "layers" in an application. we are changing the user interface, adding fields to models, modifying validation, and so on. Instead of coupling across a layer, we couple vertically along a slice and each change affects only one slice.
- We `Minimize coupling` `between slices`, and `maximize coupling` `in a slice`.
- With this approach, each of our vertical slices can decide for itself how to best fulfill the request. New features only add code, we're not changing shared code and worrying about side effects. For implementing vertical slice architecture using cqrs pattern is a good match.

## Project References

- https://github.com/oskardudycz/EventSourcing.NetCore
- https://github.com/dotnet-architecture/eShopOnContainers
- https://github.com/jbogard/ContosoUniversityDotNetCore-Pages
- https://github.com/kgrzybek/modular-monolith-with-ddd
- https://github.com/thangchung/clean-architecture-dotnet