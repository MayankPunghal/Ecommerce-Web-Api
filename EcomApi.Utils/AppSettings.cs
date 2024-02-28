using System.Text.Json;

namespace EcomApi.Utils
{
    public class AppSettings
    {
        public static Setting Settings { get; }
        static AppSettings()
        {
            var config = File.ReadAllText("appsettings.json");
            Settings = JsonSerializer.Deserialize<Setting>(config) ?? throw new InvalidOperationException();
        }
        //public class Preferences
        //{
        //    public static int Offset => Convert.ToInt32(Settings.AppSettings.Offset);
        //}

        public class Setting
        {
            public Sqlconnection? SqlConnection { get; init; }
            public Jwt? Jwt { get; init; }
            public MailSettings MailSettings { get; init; } 
        }
        public class Sqlconnection
        {
            public EcomDB? EcomDB { get; init; }
        }
        public class EcomDB
        {
            public string? ConnectionString { get; init; }
            public int CommandTimeout { get; init; }
        }
        public class Jwt
        {
            public string SecretKey { get; init; }
            public string? Issuer { get; init; }
            public string? Audience { get; init; }
            public int ExpirationMinutes { get; init; }
            public bool IsAuthenticationOn { get; set; }
        }

        public class MailSettings
        {
            public Smtp Smtp { get; init; }
        }
        public class Smtp
        {
            public string From { get; init; }
            public string DeliveryMethod { get; init; }
            public Network Network { get; init; }
        }
        public class Network
        {
            public string Name { get; init; }
            public bool DefaultCredentials { get; set; }
            public string Host { get; init; }
            public int Port { get; init; }
            public bool EnableSsl { get; init; }
            public string UserName { get; init; }
            public string Password { get; init; }
        }
    }
}
