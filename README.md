
# TT-ECommerce

**TT-ECommerce** is a fictional eCommerce, built with .Net Core and different software architecture and technologies like Microservices Architecture, Vertical Slice Architecture, CQRS Pattern, Domain Driven Design (DDD), Event Driven Architecture.

## Architecture
The overall architecture is organized with `Core`, `Crosscutting` and `Services`.

### Core
It defines all the building blocks and abstractions to be used on every underlying project.

### Core.Infrastructure
It implements infrastructure matters to be used by microservices. Also, it centralizes third-party packages.

### Crosscutting
It contains projects with logic needed to cross over the microservices, such as `IdentityServer` and `API gateway`.

### Services
The microservices composing the back-end, are built to be as simple as possible, structured with `Domain`, `Application`, `API`, `Infrastructure`.

#### - Domain

This is where the business logic resides, with a structured implementation of the domain through aggregates, commands, value objects, domain services, repository definitions, and domain events.

#### - Application

It orchestrates the interactions between the external world and the domain to perform application tasks through use cases by handling commands and queries. 

#### - Infrastructure

It acts as a supporting library for higher layers. It handles infrastructural matters and data persistence.

## Technologies used
<ul>
  <li>
    <a href='https://get.asp.net' target="_blank">ASP.NET Core API</a> and <a href='https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-12' target="_blank">C# 12</a>
    for cross-platform backend with:
    <ul>
      <li>.NET 7</li>
      <li>Ocelot</li>
      <li>Marten</li>
      <li>Entity Framework Core </li>
      <li>Postgres for Entity Framework Core</li>
      <li>ASP.NET Core Identity</li>
      <li>ASP.NET Core Authentication JwtBearer</li>
      <li>Duende IdentityServer</li>
      <li>MediatR</li>
      <li>Polly</li>
      <li>Fluent Assertions</li>
      <li>XUnit</li>
      <li>NSubstitute</li>
      <li>Swagger</li>
      <li>Confluent Kafka</li>
    </ul>
  </li>
  <li>
    <a href='https://angular.io/' target="_blank">Angular 16</a> and <a href='http://www.typescriptlang.org/' 
target="_blank">TypeScript 5.2.0</a> for the frontend with:
    <ul>
      <li>NgBootstrap 16.0.0/ Bootstrap 5.2.3</li>
      <li>Font Awesome 6.4.</li>
      <li>Toastr 17.0.2</li>
    </ul>
  </li>
</ul>

### References
- <a href="https://learn.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications" target="_blank">Designing and Developing
  Multi-Container and Microservice-Based .NET Applications</a>
- <a href="https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns" target="_blank">Tackle Business Complexity in a Microservice with DDD and CQRS Patterns</a>
- <a href="https://event-driven.io/en/using_strongly_typed_ids_with_marten" target="_blank">Using strongly-typed identifiers with Marten</a>
- <a href="https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/implement-value-objects" target="_blank">Implement value objects</a>
- <a href="https://talkdotnet.wordpress.com/2019/03/15/newtonsoft-json-deserializing-objects-that-have-private-setters" target="_blank">Newtonsoft Json – Deserializing objects that have private setters</a>
- <a href="https://debezium.io/documentation/reference/stable/transformations/outbox-event-router.html" target="_blank">Outbox Event Router</a>
- <a href="https://viblo.asia/p/kafka-khai-niem-co-ban-part-1-vlZL9aDdLQK" target="_blank">Kafka</a>
- <a href="https://dev.to/n_develop/mocking-the-httpclient-in-net-core-with-nsubstitute-k4j" target="_blank">Mocking the HttpClient in .NET Core (with NSubstitute)</a>
