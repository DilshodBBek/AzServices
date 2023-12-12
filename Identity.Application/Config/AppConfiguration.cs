namespace Identity.Application;

public class AppConfiguration
{
    public Logging Logging { get; set; }
    public string AllowedHosts { get; set; }
    public ConnectionStrings ConnectionStrings { get; set; }
    public JWTKeyConfiguration JWTKey { get; set; }
}

public class Logging
{
    public LogLevel LogLevel { get; set; }
}

public class LogLevel
{
    public string Default { get; set; }
    public string MicrosoftAspNetCore { get; set; }
}

public class ConnectionStrings
{
    public string DefaultConnection { get; set; }
}

public class JWTKeyConfiguration
{
    public string ValidAudience { get; set; }
    public string ValidIssuer { get; set; }
    public string TokenExpiryTimeInHour { get; set; }
    public string Secret { get; set; }
}
