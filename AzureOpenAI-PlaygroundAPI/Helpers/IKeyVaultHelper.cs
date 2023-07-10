namespace AzureOpenAI_PlaygroundAPI.Helpers
{
    public interface IKeyVaultHelper
    {
        public Task<string> GetKeyVaultSecret(string secretName);
    }
}
