﻿using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.SubscribeDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
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

        public async Task<IActionResult> AddBooking(CreateBookingDto createBookingDto)
        {
            createBookingDto.Description=string.Empty;
            createBookingDto.Status = "Onay Bekliyor.";
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            await client.PostAsync("http://localhost:21771/api/Booking", stringContent);

            return RedirectToAction("Index", "Default");
        }
    }
}
