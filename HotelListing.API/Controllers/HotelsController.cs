﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing.API.Data;
using HotelListing.API.Interfaces;
using AutoMapper;
using HotelListing.API.Models.Country;
using HotelListing.API.Models.Hotel;
using Microsoft.AspNetCore.Authorization;
using HotelListing.API.Models;

namespace HotelListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;

        public HotelsController(IHotelRepository hotelRepository, IMapper mapper)
        {
            this._hotelRepository = hotelRepository;
            this._mapper = mapper;
        }

        // GET: api/Hotels/GetAll
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDto>>> GetHotels()
        {
            var hotels = await _hotelRepository.GetAllAsync();
            var records = _mapper.Map<List<HotelDto>>(hotels);
            return Ok(records);
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<PagedResult<HotelDto>>> GetPagedHotels([FromQuery] QueryParameters queryParameters)
        {
            var pagedHotelsResult = await _hotelRepository.GetAllAsync<HotelDto>(queryParameters);
            return Ok(pagedHotelsResult);
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDto>> GetHotel(int id)
        {
            var hotel = await _hotelRepository.GetAsync(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return _mapper.Map<HotelDto>(hotel);
        }

        // PUT: api/Hotels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, HotelDto hotelDto)
        {
            if (id != hotelDto.HotelId)
            {
                return BadRequest("Wrong ID on hotel, please choose correct ID.");
            }

            var hotel = await _hotelRepository.GetAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            _mapper.Map(hotelDto, hotel);

            try
            {
                await _hotelRepository.UpdateAsync(hotel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await HotelExistsAsync(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Hotels
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(CreateHotelDto hotelDto)
        {
            var hotel = _mapper.Map<Hotel>(hotelDto);
            await _hotelRepository.AddAsync(hotel);

            return CreatedAtAction("GetHotel", new { id = hotel.HotelId }, hotel);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var hotel = await _hotelRepository.GetAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            await _hotelRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> HotelExistsAsync(int id)
        {
            return await _hotelRepository.Exists(id);
        }
    }
}
