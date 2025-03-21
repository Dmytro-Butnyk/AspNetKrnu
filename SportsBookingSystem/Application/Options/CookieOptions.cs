namespace Application.Options;

public class CookieOptions
{
    public required bool HttpOnly { get; set; }
    public required bool Secure { get; set; }
    public required string SameSite { get; set; }
    public required int ExpiresInHours { get; set; }
}