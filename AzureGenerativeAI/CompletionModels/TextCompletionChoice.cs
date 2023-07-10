using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace AzureGenerativeAI.CompletionModels
{
    public class TextCompletionChoice
    {
        public string Text { get; set; }
        public int Index { get; set; }

        [JsonProperty("finish_reason")]
        public string FinishReason { get; set; }
    }
}