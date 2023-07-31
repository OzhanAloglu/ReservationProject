using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.GuestDto;
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
            //Api Consume işlemi böyle yapılır. Bunu yapmadan önce, API katmanında Program.cs içinde gerekli konfigürasyonları yapmak gerekiyor. 


            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:21771/api/Booking");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        public async Task<IActionResult> ApprovedReservartion(ApprovedReservationDto approvedReservationDto)
        {
         
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(approvedReservationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:21771/api/Booking/ReservationStatus2", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View();

        }


        public async Task<IActionResult> ApprovedReservartion2(int id)
        {

            var client = _httpClientFactory.CreateClient();
           
          
            var responseMessage = await client.GetAsync($"http://localhost:21771/api/Booking/ReservationBookingAproved?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View();

        }

        public async Task<IActionResult> CancelReservartion(int id)
        {

            var client = _httpClientFactory.CreateClient();


            var responseMessage = await client.GetAsync($"http://localhost:21771/api/Booking/ReservationBookingCancel?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View();

        }

        public async Task<IActionResult> WaitReservartion(int id)
        {

            var client = _httpClientFactory.CreateClient();


            var responseMessage = await client.GetAsync($"http://localhost:21771/api/Booking/ReservationBookingWait?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> UpdateBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:21771/api/Booking/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData);
                return View(values);

            }
            return View();
        }



        [HttpPost]

        public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBookingDto)
        {
           
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(updateBookingDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("http://localhost:21771/api/Booking/UpdateBooking/", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");

                }
                return View();
           

        }
    }
}
