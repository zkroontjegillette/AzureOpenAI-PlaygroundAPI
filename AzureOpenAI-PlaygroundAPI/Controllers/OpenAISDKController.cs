using Azure.AI.OpenAI;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using AzureOpenAI_PlaygroundAPI.Helpers;

namespace AzureOpenAI_PlaygroundAPI.Controllers
{
    [ApiController]
    public class OpenAISDKController : ControllerBase
    {

        private readonly ILogger<OpenAISDKController> _logger;
        private OpenAIClient _openAIClient;
        private IKeyVaultHelper _keyVaultHelper;
        private readonly string MODEL_NAME = "api-playground-deployment";
        private readonly string MODEL_ENDPOINT = "https://openai-explorative-playground.openai.azure.com/";

        public OpenAISDKController(ILogger<OpenAISDKController> logger, IConfiguration iConfig, IKeyVaultHelper keyVaultHelper)
        {
            _logger = logger;
            _keyVaultHelper = keyVaultHelper;
        }

        [Route("sdk/complete-text")]
        [HttpGet]
        public async Task<Response<Completions>> GetPromptResponse()
        {
            var apiKey = await _keyVaultHelper.GetKeyVaultSecret("OpenAiApiKey");
            _openAIClient = new OpenAIClient(new Uri(MODEL_ENDPOINT), new AzureKeyCredential(apiKey));
            Response<Completions> response = await _openAIClient.GetCompletionsAsync(
            MODEL_NAME, // assumes a matching model deployment or model name
            "Hello, world!");

            return response;
        }
    }
}