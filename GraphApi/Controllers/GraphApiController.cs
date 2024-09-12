using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GraphApi.Controllers
{
    public class GraphApiController : Controller
    {
        public GraphApiController() { 
        }
        [HttpGet("{token}")]
        public async Task<string> GetAsync(string token)
        {
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await httpClient.GetAsync("https://graph.microsoft.com/v1.0/me/events");
                var content = await response.Content.ReadAsStringAsync();

                return content.ToString();
            }
        }
    }
}
