using Microsoft.AspNetCore.Mvc;
using AzureGenerativeAI;
using AzureGenerativeAI.CompletionModels;
using AzureGenerativeAI.ImageGenerationModels;
using AzureOpenAI_PlaygroundAPI.Helpers;

namespace AzureOpenAI_PlaygroundAPI.Controllers
{
    [ApiController]
    public class OpenAIRestController : ControllerBase
    {
        private readonly string _apiBaseUrl= "https://openai-explorative-playground.openai.azure.com/openai/deployments/api-playground-deployment";
        private readonly ICompletionsService _completionsService;
        private readonly IImageGenerationService _imageGenerationService;
        private readonly IKeyVaultHelper _keyVaultHelper;

        public OpenAIRestController(ILogger<OpenAISDKController> logger, ICompletionsService completionsApi, IImageGenerationService imageGenerationService, IKeyVaultHelper keyVaultHelper)
        {
            _completionsService = completionsApi;
            _imageGenerationService = imageGenerationService;
            _keyVaultHelper = keyVaultHelper;
        }

        [Route("rest/complete-text")]
        [HttpPost]
        public async Task<TextCompletionResponse> PostTextCompletion([FromBody] TextCompletionRequest request)
        {
            var apiKey = await _keyVaultHelper.GetKeyVaultSecret("OpenAiApiKey");
            return await _completionsService.CompleteTextPrompt(request, _apiBaseUrl, apiKey);
        }

        [Route("rest/complete-chat")]
        [HttpPost]
        public async Task<ChatCompletionResponse> PostChatCompletion([FromBody] ChatCompletionRequest request)
        {
            var apiKey = await _keyVaultHelper.GetKeyVaultSecret("OpenAiApiKey");
            return await _completionsService.CompleteChatPrompt(request, $"{_apiBaseUrl}", apiKey);
        }

        [Route("rest/generate-image")]
        [HttpPost]
        public async Task<ImageGenerationResponse> PostImageGeneration([FromBody] ImageGenerationRequest request)
        {
            var apiKey = await _keyVaultHelper.GetKeyVaultSecret("OpenAiApiKey");
            return await _imageGenerationService.GenerateImage(request, $"{_apiBaseUrl}", apiKey);
        }
    }
}
