using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureGenerativeAI.CompletionModels
{
    public class ChatCompletionResponse : AiModelResponseBase
    {
        public IList<ChatCompletionChoice> Choices { get; set; }
        public ChatCompletionUsage Usage { get; set; }
    }
}
