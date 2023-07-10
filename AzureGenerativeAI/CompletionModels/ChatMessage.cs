using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureGenerativeAI.CompletionModels
{
    public class ChatMessage
    {
        [DefaultValue("system")]
        [JsonProperty("role")]
        public string Role { get; set; }

        [DefaultValue("You are a helpful assistant.")]
        [JsonProperty("content")]
        public string Content { get; set; }
    }
}
