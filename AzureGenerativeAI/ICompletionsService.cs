using AzureGenerativeAI.CompletionModels;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureGenerativeAI
{
    public interface ICompletionsService
    {
        public Task<TextCompletionResponse> CompleteTextPrompt(TextCompletionRequest textCompletionRequest, string baseAddress, string apiKey);
        public Task<ChatCompletionResponse> CompleteChatPrompt(ChatCompletionRequest chatCompletionRequest, string baseAddress, string apiKey);
    }
}
