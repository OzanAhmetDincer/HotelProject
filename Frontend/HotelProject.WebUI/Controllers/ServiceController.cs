﻿using HotelProject.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ServiceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();// Bir tane istemci oluşturduk
            var responseMessage = await client.GetAsync("http://localhost:12091/api/Service");// Veri listelemek istediğimiz için "GetAsync" metodunu kullandık. Bu metot bizden bir url ister yani nereye istekte bulunacağımızı belirtiriz
            if (responseMessage.IsSuccessStatusCode)// Başarılı bir durum kodu dönerse yani 200-299 arasında ki başarılı dönüşlerde çalışacak
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();// "responseMessage" dan gelen content'in içeriği "ReadAsStringAsync" olarak oku. Gelen veriyi "jsonData" değişkeni içerisine atadık
                var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);// Bize json türünde bir veri geldiği için onu "Deserialize" yapmamız gerekir. Bu objede List içerisinde gelen ya entity'i yada view bilgisini dönmemiz gerek. Bir şey dönebilmek için de viewmodel'e ihtiyaç var. jsonData dan gelen verileri göndericez.
                return View(values);
            }
            return View();
        }


        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddService(CreateServiceDto createServiceDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var client = _httpClientFactory.CreateClient();// Bir tane istemci oluşturduk
            var jsonData = JsonConvert.SerializeObject(createServiceDto);// Burada ise yeni eklenecek olan bir veriyi json formatına dönüştürmemiz lazım. "SerializeObject" ile bu işlemi yaparız. oluşturduğumuz nesneyi bizim için Json string’e çevirdi.

            // "StringContent" içeriğin dönüşümü için kullanacağımız bir sınıf. Web api sunucusuna bir nesne göndermek istediğimde, HTTP içeriğine format eklemek için StringContent'i kullanırım, örneğin Müşteri nesnesini sunucuya json olarak eklemek için. StringContent sınıfı, http sunucu/istemci iletişimine uygun biçimlendirilmiş bir metin oluşturur. Bir istemci isteğinden sonra sunucu HttpResponseMessageve ile yanıt verecektir  bu yanıtın bir içeriğe ihtiyacı olacaktır bunu da StringContent sınıfla oluşturulabiliriz  
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");// jsonData ile içeriğimizi veririz, Encoding.UTF8 ile de Türkçe karakter destekleyecek şekilde getirdik mediaType ise application/json olacak. Veri, verinin kodlanmış hali ve türü
            var responseMessage = await client.PostAsync("http://localhost:12091/api/Service", stringContent);// Ekleme yapabilmek için "PostAsync" metodunu kullanırız
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteService(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:12091/api/Service/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> UpdateService(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:12091/api/Service/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateServiceDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateServiceDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:12091/api/Service/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
