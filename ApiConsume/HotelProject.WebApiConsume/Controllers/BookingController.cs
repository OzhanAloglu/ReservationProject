using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApiConsume.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetList();
            return Ok(values);
        }

        [HttpPost]

        public IActionResult AddBooking(Booking booking)
        {
            _bookingService.TInsert(booking);
            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var values = _bookingService.TGetById(id);
            _bookingService.TDelete(values);
            return Ok();
        }



        [HttpPut("UpdateBooking")]
        public IActionResult UpdateBooking(Booking booking)
        {
            _bookingService.TUpdate(booking);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var values = _bookingService.TGetById(id);
            return Ok(values);
        }



        [HttpPut("ReservationStatus")]
        public IActionResult ReservationStatus(Booking booking)
        {
            _bookingService.BookingStatusChangeApproved(booking);
            return Ok();
        }


        [HttpPut("ReservationStatus2")]
        public IActionResult ReservationStatus2(int id)
        {
            _bookingService.BookingStatusChangeApproved2(id);
            return Ok();
        }

        [HttpGet("Last6Booking")]
        public IActionResult Last6Booking()
        {
          var values=  _bookingService.TLast6Bookings();
            return Ok(values);
        }


        [HttpGet("ReservationBookingAproved")]

        public IActionResult ReservationBookingAproved(int id)
        {
            _bookingService.TBookingStatusChangeApproved3(id);
            return Ok();
        }

    }
}
