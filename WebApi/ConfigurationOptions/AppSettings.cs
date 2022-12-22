namespace WebApi.ConfigurationOptions
{
    public class AppSettings
    {
        public ConnectionStrings connectionStrings { get; set; }
        public IdentityAuthentication identityAuthentication { get; set; }
        public MailSettings mailSettings { get; set; }
    }
}
