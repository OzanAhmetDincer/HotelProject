using HotelProject.WebUI.Dtos.TestimonialDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class _TestimonialPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _TestimonialPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();// Bir tane istemci oluşturduk
            var responseMessage = await client.GetAsync("http://localhost:12091/api/Testimonial");// Veri listelemek istediğimiz için "GetAsync" metodunu kullandık. Bu metot bizden bir url ister yani nereye istekte bulunacağımızı belirtiriz
            if (responseMessage.IsSuccessStatusCode)// Başarılı bir durum kodu dönerse yani 200-299 arasında ki başarılı dönüşlerde çalışacak
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();// "responseMessage" dan gelen content'in içeriği "ReadAsStringAsync" olarak oku. Gelen veriyi "jsonData" değişkeni içerisine atadık
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);// Bize json türünde bir veri geldiği için onu "Deserialize" yapmamız gerekir. Bu objede List içerisinde gelen ya entity'i yada view bilgisini dönmemiz gerek. Bir şey dönebilmek için de viewmodel'e ihtiyaç var. jsonData dan gelen verileri göndericez.
                return View(values);
            }
            return View();
        }
    }
}
