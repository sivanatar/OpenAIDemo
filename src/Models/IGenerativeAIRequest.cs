using System.Text.Json.Serialization;

namespace TutorialOpenAI.Models
{
    public interface IGenerativeAIRequest
    {
        [JsonPropertyName("model")]
        public string Model { get; set; }

        [JsonPropertyName("prompt")]
        public string Prompt { get; set; }

        [JsonPropertyName("temperature")]
        public float Temperature { get; set; }

        [JsonPropertyName("max_tokens")]
        public int MaxTokens { get; set; }

        [JsonIgnore]
        public string Mode { get; set; }
    }
}
