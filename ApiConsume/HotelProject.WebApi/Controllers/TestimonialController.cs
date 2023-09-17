using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        [HttpGet]// Verileri getirecek olan kısım. O yüzden bu atribute'yi ekleriz
        public IActionResult TestimonialList()
        {
            var values = _testimonialService.TGetList();
            return Ok(values);
        }
        [HttpPost]// Yeni veri ekleme
        public IActionResult AddTestimonial(Testimonial testimonial)
        {
            _testimonialService.TInsert(testimonial);
            return Ok();
        }
        [HttpDelete("{id}")]// Veri silme
        public IActionResult DeleteTestimonial(int id)
        {
            var values = _testimonialService.TGetByID(id);
            _testimonialService.TDelete(values);
            return Ok();
        }
        [HttpPut]// Güncelleme
        public IActionResult UpdateTestimonial(Testimonial testimonial)
        {
            _testimonialService.TUpdate(testimonial);
            return Ok();
        }
        [HttpGet("{id}")]// id parametresine göre getirme işlemi yapılacak
        public IActionResult GetTestimonial(int id)
        {
            var values = _testimonialService.TGetByID(id);
            return Ok(values);
        }
    }
}
