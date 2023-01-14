using Infrastructure.Storages;

namespace WebApi.ConfigurationOptions
{
    public class AppSettings
    {
        //public ConnectionStrings connectionStrings { get; set; }
        public IdentityAuthentication IdentityAuthentication { get; set; }
        public MailSettings MailSettings { get; set; }
        public StorageOptions Storage { get; set; }

    }
}
