namespace TTEcommerce.IdentityServer.Database;

public static class MigrationManager
{
    public static IHost MigrateDatabase(this IHost host)
    {
        using (var scope = host.Services.CreateScope())
        {
            scope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

            using (var context = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>())
            {
                context.Database.Migrate();

                if (!context.Clients.Any())
                {
                    foreach (var client in IdentityConfiguration.Clients)
                        context.Clients.Add(client.ToEntity());

                    context.SaveChanges();
                }

                if (!context.IdentityResources.Any())
                {
                    foreach (var resource in IdentityConfiguration.IdentityResources)
                        context.IdentityResources.Add(resource.ToEntity());

                    context.SaveChanges();
                }

                if (!context.ApiResources.Any())
                {
                    foreach (var apiResource in IdentityConfiguration.ApiResources)
                        context.ApiResources.Add(apiResource.ToEntity());

                    context.SaveChanges();
                }

                if (!context.ApiScopes.Any())
                {
                    foreach (var apiScope in IdentityConfiguration.ApiScopes)
                        context.ApiScopes.Add(apiScope.ToEntity());

                    context.SaveChanges();
                }
            }

            return host;
        }
    }
}
