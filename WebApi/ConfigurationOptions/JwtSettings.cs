namespace WebApi.ConfigurationOptions
{
    public class JwtSettings
    {
        public string Authority { get; set; }
        public string ApiName { get; set; }
        public bool RequireHttpsMetadata { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecretKey { get; set; }
        public string Prefix { get; set; }
        public int Expires { get; set; }
    }
}
