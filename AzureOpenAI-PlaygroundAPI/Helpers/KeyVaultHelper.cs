using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace AzureOpenAI_PlaygroundAPI.Helpers
{
    public class KeyVaultHelper : IKeyVaultHelper
    {
        private readonly SecretClient _secretClient;

        public KeyVaultHelper (IConfiguration iConfig)
        {
            string kvUri = iConfig.GetValue<string>("KeyVaultUrl");
            _secretClient = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());
        }

        public async Task<string> GetKeyVaultSecret(string secretName)
        {
            var keyVaultSecret = await _secretClient.GetSecretAsync(secretName);
            return keyVaultSecret.Value.Value.ToString();
        }
    }
}
