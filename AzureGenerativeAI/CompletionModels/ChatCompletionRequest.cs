using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureGenerativeAI.CompletionModels
{
    public class ChatCompletionRequest
    {
        [JsonProperty("messages")]
        public IList<ChatMessage> Messages { get; set; }
    }
}
