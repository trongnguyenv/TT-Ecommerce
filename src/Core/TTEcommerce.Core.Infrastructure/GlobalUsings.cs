global using System.Text;
global using System.Net.Http.Headers;
global using Newtonsoft.Json;
global using MediatR;
global using Polly;
global using NSubstitute;
global using Confluent.Kafka;
global using Marten;
global using Marten.Linq;
global using Weasel.Core;
global using System.Net.Mime;
global using Newtonsoft.Json.Linq;
global using System.Linq.Expressions;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.DependencyInjection.Extensions;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.OpenApi.Models;
global using System.IdentityModel.Tokens.Jwt;
global using IdentityModel.Client;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Http;
global using Microsoft.Extensions.Caching.Memory;
global using Microsoft.AspNetCore.Authentication;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.Extensions.Configuration;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.Extensions.Options;
global using JasperFx.Core.Reflection;

global using TTEcommerce.Core.EventBus;
global using TTEcommerce.Core.Persistence;
global using TTEcommerce.Core.Domain;
global using TTEcommerce.Core.Testing;
global using TTEcommerce.Core.Reflection;
global using TTEcommerce.Core.CQRS.CommandHandling;
global using TTEcommerce.Core.CQRS.QueryHandling;
global using TTEcommerce.Core.Infrastructure.CQRS;
global using TTEcommerce.Core.Infrastructure.EventBus;
global using TTEcommerce.Core.Infrastructure.Identity;
global using TTEcommerce.Core.Infrastructure.Http;
global using TTEcommerce.Core.Infrastructure.Integration;
global using TTEcommerce.Core.Infrastructure.WebApi;
global using TTEcommerce.Core.Infrastructure.Workers;
global using TTEcommerce.Core.Infrastructure.Outbox.Workers;
global using TTEcommerce.Core.Infrastructure.Kafka.Serialization;
global using TTEcommerce.Core.Infrastructure.Kafka.Consumer;
global using TTEcommerce.Core.Infrastructure.Kafka.Workers;
global using TTEcommerce.Core.Infrastructure.Outbox;
