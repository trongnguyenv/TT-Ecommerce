namespace TTEcommerce.IdentityServer.Configurations;

public class IdentityConfiguration
{
    private const string _apiScope = "tt_ecommerce-api.scope";
    private const string _readScope = "read";
    private const string _writeScope = "write";
    private const string _deletecope = "delete";

    public static IEnumerable<IdentityResource> IdentityResources =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email()
        };

    public static IEnumerable<ApiResource> ApiResources =>
        new List<ApiResource>
        {
            new("tt_ecommerce-api")
            {
                Scopes = new List<string>
                {
                    _apiScope,
                    _readScope,
                    _writeScope,
                    _deletecope
                }
            }
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new(_apiScope, "TT_Ecommerce"),
            new(_readScope, "Read your data."),
            new(_writeScope, "Write your data."),
            new(_deletecope, "Delete your data.")
        };

    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            // User's client
            new()
            {
                ClientId = "tt_ecommerce.user_client",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                RequireClientSecret = true,
                ClientSecrets = new List<Secret> { new("secret234432^&%&^%&^f2%%%".Sha256()) },
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    _readScope,
                    _writeScope,
                    _deletecope
                },
                // #https://auth0.com/docs/secure/tokens/access-tokens/update-access-token-lifetime
                AccessTokenLifetime = 86400 // Default value is 86,400 seconds (24 hours)
            },

            // machine to machine client
            new()
            {
                ClientId = "tt_ecommerce.application_client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                RequireClientSecret = true,
                ClientSecrets = new List<Secret> { new("secret235432^&%&^%&^f2%%%".Sha256()) },
                AllowedScopes =
                {
                    _apiScope,
                    _readScope,
                    _writeScope,
                    _deletecope
                },
                AccessTokenLifetime = 86400
            }
        };
}
