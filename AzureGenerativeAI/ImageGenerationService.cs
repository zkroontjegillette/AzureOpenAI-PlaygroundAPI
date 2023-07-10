using AzureGenerativeAI.ImageGenerationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureGenerativeAI
{
    public class ImageGenerationService : IImageGenerationService
    {
        public Task<ImageGenerationResponse> GenerateImage(ImageGenerationRequest imageGenerationRequest, string baseAddress, string apiKey)
        {
            throw new NotImplementedException();
        }
    }
}
