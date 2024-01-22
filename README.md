
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
