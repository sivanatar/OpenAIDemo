using TutorialOpenAI.Models;

namespace TutorialOpenAI.Services
{
    public interface IGenerativeService
    {
        public IGenerativeAIResponse GenerateText(IGenerativeAIRequest request);
    }
}
