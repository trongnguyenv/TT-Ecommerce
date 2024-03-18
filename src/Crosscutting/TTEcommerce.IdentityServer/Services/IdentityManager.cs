namespace TTEcommerce.IdentityServer.Services;

public class IdentityManager : IIdentityManager
{
    private readonly TokenIssuerSettings _issuerSettings;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ITokenRequester _tokenRequester;
    private readonly UserManager<ApplicationUser> _userManager;

    public IdentityManager(
        ITokenRequester tokenRequester,
        UserManager<ApplicationUser> userManager,
        IOptions<TokenIssuerSettings> issuerSettings,
        RoleManager<IdentityRole> roleManager)
    {
        _tokenRequester = tokenRequester;
        _userManager = userManager;
        _issuerSettings = issuerSettings.Value;
        _roleManager = roleManager;
    }

    public async Task<TokenResponse> AuthUserByCredentials(LoginRequest request)
    {
        var response = await _tokenRequester.GetUserTokenAsync(
            _issuerSettings,
            request.Email, request.Password);

        if (response.HttpStatusCode == HttpStatusCode.BadRequest)
            throw new ApplicationException($"Invalid username or password.");

        return response;
    }

    public async Task<IdentityResult> RegisterNewUser(RegisterUserRequest request)
    {
        await AddDefaultRoles();

        var user = new ApplicationUser
        {
            UserName = request.Email,
            Email = request.Email,
            EmailConfirmed = true
        };

        // Creating user
        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
            throw new ApplicationException(result.Errors.First().Description);

        // Adding role
        result = await _userManager.AddClaimsAsync(user,
            new Claim[]
            {
                new(JwtClaimTypes.Name, user.UserName),
                new(JwtClaimTypes.Email, user.Email),
                new(JwtClaimTypes.Role, Roles.Customer)
            });

        if (!result.Succeeded)
            throw new ApplicationException($"Can't add claims for {user.Email}");

        return result;
    }

    private async Task AddDefaultRoles()
    {
        var clientRole = await _roleManager.FindByNameAsync(Roles.Customer);

        if (clientRole is null)
        {
            var result = await _roleManager.CreateAsync(new IdentityRole(Roles.Customer));

            if (!result.Succeeded)
                throw new ApplicationException($"Can't add role {Roles.Customer}");
        }

        await Task.CompletedTask;
    }
}