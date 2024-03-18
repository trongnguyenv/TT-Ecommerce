## ASP.NET Core Identity
- I implemented it using the same Postgresql server instance we saw for persisting domain events, now but for setting 
up a
 database outputting ASP.NET Core Identity migrations, you’ll find it in the Database/Migrations folder.

- For this specific set of migrations, I’m using the IdentityApplicationDbContext, and I added migrations using:

  `` dotnet ef migrations add InitialMigration -c IdentityApplicationDbContext -o Database/Migrations ``

## IdentityServer
- IdentityServer is an OpenID Connect and OAuth 2.0 framework for ASP.NET Core.
- IdentityServer is handy for authentication and can be easily integrated with ASP.NET Core Identity
  - Two more migrations were added to complete the persistence ready for IdentityServer:
  
  ``dotnet ef migrations add InitialIdentityServerConfigurationDbMigration -c ConfigurationDbContext -o Database/Migrations/IdentityServer/ConfigurationDb``

  ``dotnet ef migrations add InitialIdentityServerPersistedGrantDbMigration -c PersistedGrantDbContext -o Database/Migrations/IdentityServer/PersistedGrantDb``
 
  - Update database:

  ``dotnet ef database update -c IdentityApplicationDbContext``

  ``dotnet ef database update -c ConfigurationDbContext``
 
  ``dotnet ef database update -c PersistedGrantDbContext``
