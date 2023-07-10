using AzureGenerativeAI.CompletionModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace AzureGenerativeAI
{
    public class CompletionsService : ICompletionsService
    {
        private readonly int MAX_TOKENS_NEW_MODELS = 4096;
        private readonly int MAX_TOKENS_OLD_MODELS = 2048;
        private string _generativeModel = "gpt-3.5-turbo";
        private readonly RestClient _client;
        //curl https://YOUR_RESOURCE_NAME.openai.azure.com/openai/deployments/YOUR_DEPLOYMENT_NAME
        private readonly string _textCompletionsApiRoute = "/completions?api-version=2022-12-01";
        private readonly string _chatCompletionsApiRoute = "/chat/completions?api-version=2023-05-15";

        public CompletionsService()
        {
            _client = new RestClient();
        }

        public async Task<TextCompletionResponse> CompleteTextPrompt(TextCompletionRequest textCompletionRequest, string baseAddress, string apiKey)
        {
            try
            {
                textCompletionRequest.MaxTokens = GetMaxTokenInput(_generativeModel, textCompletionRequest.Prompt, textCompletionRequest.MaxTokens);

                // do request
                var requestContent = JsonConvert.SerializeObject(textCompletionRequest);
                string textCompletionsApiRoute = $"{baseAddress}{_textCompletionsApiRoute}";
                var restRequest = CreateRestRequest(requestContent, apiKey, textCompletionsApiRoute);
                var response = await _client.ExecuteAsync(restRequest).ConfigureAwait(false);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new HttpRequestException(response.ErrorMessage);
                }
                return JsonConvert.DeserializeObject<TextCompletionResponse>(response.Content);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<ChatCompletionResponse> CompleteChatPrompt(ChatCompletionRequest chatCompletionRequest, string baseAddress, string apiKey)
        {
            try
            {
                // do request
                var requestContent = JsonConvert.SerializeObject(chatCompletionRequest, Formatting.Indented);
                string textCompletionsApiRoute = $"{baseAddress}{_chatCompletionsApiRoute}";
                var restRequest = CreateRestRequest(requestContent, apiKey, textCompletionsApiRoute);
                var response = await _client.ExecuteAsync(restRequest).ConfigureAwait(false);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new HttpRequestException(response.ErrorMessage);
                }
                return JsonConvert.DeserializeObject<ChatCompletionResponse>(response.Content);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private static RestRequest CreateRestRequest(string requestContent, string apiKey, string textCompletionsApiRoute)
        {
            var restRequest = new RestRequest(textCompletionsApiRoute, Method.Post);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("api-key", apiKey);
            restRequest.AddBody(requestContent, "application/json");
            return restRequest;
        }

        private int GetMaxTokenInput(string model, string prompt, int maxTokenInput)
        {
            char[] delimiters = new char[] { ' ', '\r', '\n' };
            var promptTokens = prompt.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;
            var maxTokensNewerModels = MAX_TOKENS_NEW_MODELS - promptTokens;
            var maxTokensOlderModels = MAX_TOKENS_OLD_MODELS - promptTokens;

            if ((model.Contains("gpt-3.5-turbo") || model.Contains("gpt-4")) && (maxTokenInput > maxTokensNewerModels || maxTokenInput == 0))
            {
                return maxTokensNewerModels;
            }
            else if (maxTokenInput > maxTokensOlderModels || maxTokenInput == 0)
            {
                return maxTokensOlderModels;
            }
            return maxTokenInput;
        }
    }

}