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
    }
}
