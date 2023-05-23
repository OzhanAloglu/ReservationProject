﻿using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApiConsume.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        IContactService _contactService;

        public ContactController(IContactService contactService)
        
        {
            _contactService = contactService;
        }

        [HttpPost]

        public IActionResult AddContact(Contact contact)
        {
            contact.Date=Convert.ToDateTime(DateTime.Now.ToString());
            _contactService.TInsert(contact);
            return Ok();
        }


        [HttpGet]
        public IActionResult InboxListContact()
        {
            var values = _contactService.TGetList();
            return Ok(values);
        }
    }
}
