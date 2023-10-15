using HotelProject.WebUI.Dtos.SubscribeDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult _SubscribePartial()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> _SubscribePartial(CreateSubscribeDto createSubscribeDto)
        {
            var client = _httpClientFactory.CreateClient();// Bir tane istemci oluşturduk
            var jsonData = JsonConvert.SerializeObject(createSubscribeDto);// Burada ise yeni eklenecek olan bir veriyi json formatına dönüştürmemiz lazım. "SerializeObject" ile bu işlemi yaparız. oluşturduğumuz nesneyi bizim için Json string’e çevirdi.

            // "StringContent" içeriğin dönüşümü için kullanacağımız bir sınıf. Web api sunucusuna bir nesne göndermek istediğimde, HTTP içeriğine format eklemek için StringContent'i kullanırım, örneğin Müşteri nesnesini sunucuya json olarak eklemek için. StringContent sınıfı, http sunucu/istemci iletişimine uygun biçimlendirilmiş bir metin oluşturur. Bir istemci isteğinden sonra sunucu HttpResponseMessageve ile yanıt verecektir  bu yanıtın bir içeriğe ihtiyacı olacaktır bunu da StringContent sınıfla oluşturulabiliriz  
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");// jsonData ile içeriğimizi veririz, Encoding.UTF8 ile de Türkçe karakter destekleyecek şekilde getirdik mediaType ise application/json olacak. Veri, verinin kodlanmış hali ve türü
            await client.PostAsync("http://localhost:12091/api/Subscribe", stringContent);// Ekleme yapabilmek için "PostAsync" metodunu kullanırız
            return RedirectToAction("Index" , "Default");
        }
    }
}
