namespace TTEcommerce.IdentityServer.API.Requests;

public record LoginRequest
{
    [Required] public string Email { get; set; }
    [Required] public string Password { get; set; }
}
