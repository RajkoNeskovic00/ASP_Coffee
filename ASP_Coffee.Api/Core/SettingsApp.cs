namespace ASP_Coffee.Api.Core
{
    public class SettingsApp
    {
        public string DbConnectionString { get; set; }
        public string JwtKeySecret { get; set; }
        public string JwtIssuer { get; set; }
        public string EmailFrom { get; set; }
        public string EmailPass { get; set; }
        public string AppInstance { get; set; }
    }
}
