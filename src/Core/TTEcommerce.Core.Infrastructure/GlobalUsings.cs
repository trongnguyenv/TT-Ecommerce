global using System.Text;
global using System.Net.Http.Headers;
global using Newtonsoft.Json;
global using MediatR;
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

global using TTEcommerce.Core.CQRS.CommandHandling;
global using TTEcommerce.Core.CQRS.QueryHandling;
global using TTEcommerce.Core.EventBus;
global using TTEcommerce.Core.Infrastructure.CQRS;
global using TTEcommerce.Core.Infrastructure.EventBus;
global using TTEcommerce.Core.Infrastructure.Identity;
global using TTEcommerce.Core.Persistence;
global using TTEcommerce.Core.Testing;
global using TTEcommerce.Core.Infrastructure.Http;
global using TTEcommerce.Core.Infrastructure.Integration;
global using TTEcommerce.Core.Infrastructure.WebApi;