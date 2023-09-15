﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;

namespace RapidApiConsume.Controllers
{
    public class BookingByCityController : Controller
    {
        public async Task<IActionResult> Index(string cityID)
        {
            if (!string.IsNullOrEmpty(cityID))
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v2/hotels/search?checkin_date=2023-03-24&checkout_date=2023-03-27&filter_by_currency=EUR&dest_id={cityID}&room_number=1&units=metric&dest_type=city&locale=en-gb&adults_number=2&order_by=popularity&page_number=0&children_number=2&include_adjacency=true&children_ages=5%2C0&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1"),
                    Headers =
    {
                        { "X-RapidAPI-Key", "a5cb8a2abamsh17c63a5f8d9ed06p188639jsn225db3b8fe33" },
                        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<BookingApiViewModel>(body);
                    return View(values.results.ToList());
                }
            }
            else
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://booking-com.p.rapidapi.com/v2/hotels/search?checkin_date=2023-03-24&checkout_date=2023-03-27&filter_by_currency=EUR&dest_id=-1456928&room_number=1&units=metric&dest_type=city&locale=en-gb&adults_number=2&order_by=popularity&page_number=0&children_number=2&include_adjacency=true&children_ages=5%2C0&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1"),
                    Headers =
    {
                        { "X-RapidAPI-Key", "a5cb8a2abamsh17c63a5f8d9ed06p188639jsn225db3b8fe33" },
                        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<BookingApiViewModel>(body);
                    return View(values.results.ToList());
                }
            }
        }
    }
}
