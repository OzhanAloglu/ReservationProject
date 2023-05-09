using HotelProject.WebUI.Dtos.BookingDto;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public PartialViewResult AddBooking()
        {
            return PartialView();
        }


        [HttpPost]

        public async Task<PartialViewResult> AddBooking(CreateBookingDto createBookingDto)
        {
            return PartialView();
        }
    }
}
