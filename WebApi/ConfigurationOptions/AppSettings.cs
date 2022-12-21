namespace WebApi.ConfigurationOptions
{
    public class AppSettings
    {
        public ConnectionStrings connectionStrings { get; set; }
        public JwtSettings jwtSettings { get; set; }
        public MailSettings mailSettings { get; set; }
    }
}
