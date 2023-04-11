using System.Text.Json;
using System.Text;
using TutorialOpenAI.Models;
using System.Net.Http.Headers;

namespace TutorialOpenAI.Services
{
    public class OpenAIService : IGenerativeService
    {
        public IGenerativeAIResponse GenerateText(IGenerativeAIRequest request)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "<your key>");

            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PostAsync($"https://api.openai.com/v1/{request.Mode}", content).Result;
            var resjson = response.Content.ReadAsStringAsync().Result;
            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = JsonSerializer.Deserialize<OpenAIErrorResponse>(resjson);
                throw new System.Exception(errorResponse.Error.Message);
            }
            //var data = JsonSerializer.Deserialize<OpenAIResponse>(resjson);
            var openAIResponse = JsonSerializer.Deserialize<Root>(resjson);
            return openAIResponse;
        }

    }
}
