﻿using AutoMapper;
using BarberShop.Dto;
using BarberShop.Interfaces;
using BarberShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarberController : Controller
    {
        private readonly IBarberRepository _barberRepository;
        private readonly IMapper _mapper;

        public BarberController(IBarberRepository barberRepository, IMapper mapper)
        {
            _barberRepository = barberRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200,Type= typeof(IEnumerable<Barber>))]
        public IActionResult GetBarbers()
        {
            var barbers = _mapper.Map<List<BarberGetDto>>(_barberRepository.GetBarbers().ToList());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            return Ok(barbers);
        }

        [HttpGet("/originals")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Barber>))]
        public IActionResult GetBarbersOriginals()
        {
            var barbers = _barberRepository.GetBarbers().ToList();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(barbers);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateBarber([FromBody] BarberCreateDto createBarber)
        {
            if (createBarber == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var barberMap = _mapper.Map<Barber>(createBarber);
            barberMap.CreateTime = DateTime.Now;
            barberMap.IsDeleted = false;
            barberMap.IsActive = false;

            if (!_barberRepository.CeateBarber(barberMap))
            {
                ModelState.AddModelError("", "Some Thing Went Wrong While Saving Your Entry");
                return StatusCode(500, ModelState);
            }

            return Ok("Barber Created Successfully");
        }

        [HttpPut("{barberId}/activate")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult ActivateBarber(int barberId, [FromQuery] int period , [FromQuery] DateTime date)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_barberRepository.BarberExists(barberId))
                return NotFound();

            if (!_barberRepository.ActiveBarber(barberId, date, period))
            {
                ModelState.AddModelError("", "Some Thing Went Wrong While Activating Barber");
                return StatusCode(500, ModelState);
            }
            return Ok("Barber Activated Successfully");
        }
    }
    }
}
