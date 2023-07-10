using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureGenerativeAI.CompletionModels
{
    public class ChatCompletionChoice
    {
        public int Index { get; set; }

        [JsonProperty("finish_reason")]
        public string FinishReason { get; set; }

        public ChatMessage Message { get; set; }
    }
}
