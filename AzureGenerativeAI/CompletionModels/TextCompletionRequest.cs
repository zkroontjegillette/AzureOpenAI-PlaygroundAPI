using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AzureGenerativeAI.CompletionModels
{
    public class TextCompletionRequest
    {
        [JsonProperty("prompt")]
        public string Prompt { get; set; }

        [JsonProperty("max_tokens")]
        public int MaxTokens { get; set; }
    }
}
