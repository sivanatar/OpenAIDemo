namespace TutorialOpenAI.Models
{
    public interface IGenerativeAIErrorResponse
    {
        public IGenerativeAIError? Error { get; set; }
    }
}
