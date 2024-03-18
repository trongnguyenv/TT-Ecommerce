FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Crosscutting/TTEcommerce.IdentityServer/TTEcommerce.IdentityServer.csproj", "src/Crosscutting/TTEcommerce.IdentityServer/"]
RUN dotnet restore "src/Crosscutting/TTEcommerce.IdentityServer/TTEcommerce.IdentityServer.csproj"
COPY . .
WORKDIR "/src/src/Crosscutting/TTEcommerce.IdentityServer"
RUN dotnet build "TTEcommerce.IdentityServer.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TTEcommerce.IdentityServer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TTEcommerce.IdentityServer.dll"]
