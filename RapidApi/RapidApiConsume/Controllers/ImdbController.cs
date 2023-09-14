using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;

namespace RapidApiConsume.Controllers
{
    public class ImdbController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<ApiMovieViewModel> apiMovieViewModels = new List<ApiMovieViewModel>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
    {
        { "X-RapidAPI-Key", "a5cb8a2abamsh17c63a5f8d9ed06p188639jsn225db3b8fe33" },
        { "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                apiMovieViewModels = JsonConvert.DeserializeObject<List<ApiMovieViewModel>>(body);
                return View(apiMovieViewModels);
            }
        }
    }
}
