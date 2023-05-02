using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using TutorialOpenAI.Models;
using System.Web;
using System.Xml;
using TutorialOpenAI.Services;

namespace TutorialOpenAI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Demo()
        {
            return View();
        }

        public JsonResult PostRequest(RequestViewModel requestViewModel)
        {
            var request = new OpenAIRequest
            {
                Model = requestViewModel.Model,
                Prompt = requestViewModel.Request,
                Temperature = 0.7f,
                MaxTokens = 50,
                Mode = requestViewModel.Mode
            };
            var openAIService = new OpenAIService();
            var data = openAIService.GenerateText(request);

            if (data != null && data.choices != null && data.choices.Count > 0)
            {
                var stringWriter = new StringWriter();

                HttpUtility.HtmlDecode(data.choices[0].text, stringWriter);
                string decodedString = stringWriter.ToString();
                return new JsonResult(decodedString.Trim());
            }
            return new JsonResult("No result found");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}