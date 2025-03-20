﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_EF.Models;
using WebApi_EF.Services;

namespace WebApi_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public EventsController(ApplicationDbContext context)
        {
            this.context = context;
        }
        
        [HttpGet]
        public ActionResult GetEvents()
        {
            var events = context.Events.OrderByDescending(e => e.Id).ToList();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public IActionResult GetEvent(int id)
        {
            var evt = context.Events.Find(id);
            if (evt == null)
            {
                return NotFound();
            }
            return Ok(evt);
        }

        [HttpPost]
        public IActionResult CreateEvent(EventDto eventDto)
        {
            var evt = new Event
            {
                Title = eventDto.Title,
                Description = eventDto.Description,
                Start = eventDto.Start,
                End = eventDto.End,
                AllDay = eventDto.AllDay,
                CreatedAt = DateTime.Now,
            };
            context.Events.Add(evt);
            context.SaveChanges();
            return Ok(evt);
        }


        [HttpPut("{id}")]
        public ActionResult EditEvent(int id, EventDto eventDto)
        {
            var evt = context.Events.Find(id);
            if (evt == null)
            {
                return NotFound();
            }
            evt.Title = eventDto.Title;
            evt.Description = eventDto.Description;
            evt.Start = eventDto.Start;
            evt.End = eventDto.End;
            evt.AllDay = eventDto.AllDay;
            context.SaveChanges();
            return Ok(evt);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(int id) {

            var evt = context.Events.Find(id);
            if (evt == null)
            {
                return NotFound();
            }
            context.Events.Remove(evt);
            context.SaveChanges();

            return Ok(evt);

        }

    }
}