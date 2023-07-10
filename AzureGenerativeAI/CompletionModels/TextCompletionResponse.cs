using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureGenerativeAI.CompletionModels
{
    public class TextCompletionResponse : AiModelResponseBase
    {
        public IList<TextCompletionChoice> Choices { get; set; }
    }
}
