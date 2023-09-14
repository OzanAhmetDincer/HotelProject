using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class BookingAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();// Bir tane istemci oluşturduk
            var responseMessage = await client.GetAsync("http://localhost:12091/api/Booking");// Veri listelemek istediğimiz için "GetAsync" metodunu kullandık. Bu metot bizden bir url ister yani nereye istekte bulunacağımızı belirtiriz
            if (responseMessage.IsSuccessStatusCode)// Başarılı bir durum kodu dönerse yani 200-299 arasında ki başarılı dönüşlerde çalışacak
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();// "responseMessage" dan gelen content'in içeriği "ReadAsStringAsync" olarak oku. Gelen veriyi "jsonData" değişkeni içerisine atadık
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);// Bize json türünde bir veri geldiği için onu "Deserialize" yapmamız gerekir. Bu objede List içerisinde gelen ya entity'i yada view bilgisini dönmemiz gerek. Bir şey dönebilmek için de viewmodel'e ihtiyaç var. jsonData dan gelen verileri göndericez.
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> ApprovedReservation(ApprovedReservationDto approvedReservationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(approvedReservationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:12091/api/Booking/aaaaa", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> ApprovedReservation2(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:3523/api/Booking/BookingAproved?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> CancelReservation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:3523/api/Booking/BookingCancel?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> WaitReservation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:3523/api/Booking/BookingWait?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        //[HttpGet]
        //public async Task<IActionResult> UpdateBooking(int id)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync($"http://localhost:3523/api/Booking/{id}");
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //        var values = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData);
        //        return View(values);
        //    }
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBookingDto)
        //{

        //    var client = _httpClientFactory.CreateClient();
        //    var jsonData = JsonConvert.SerializeObject(updateBookingDto);
        //    StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //    var responseMessage = await client.PutAsync("http://localhost:3523/api/Booking/UpdateBooking/", stringContent);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}
    }
}
