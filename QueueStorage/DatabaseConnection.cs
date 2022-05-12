using Microsoft.Extensions.Configuration;

namespace Console
{
    public class DatabaseConnection<T>
        where T : class
    {
        public static string GetSecret(string secretname)
        {
            var secretConfig = new ConfigurationBuilder()
                .AddUserSecrets<T>()
                .Build();
            return secretConfig[secretname];
        }
    }
}