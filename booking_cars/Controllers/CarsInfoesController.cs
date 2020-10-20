using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using booking_cars.Models;
using Microsoft.AspNetCore.Authorization;
using booking_cars.Repository;

namespace booking_cars.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CarsInfoesController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(CarsInfoesController));
        //private readonly Simulation_dbContext _context;

        //public CarsInfoesController(Simulation_dbContext context)
        //{
        //    _context = context;
        //}

        private readonly IBookingRepository _bookingRepository;

        public CarsInfoesController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        // GET: api/CarsInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarsInfo>>> GetCarsInfo()
        {
            _log4net.Info("Controller of CarsInfo");
            return Ok(_bookingRepository.GetCar());
        }

        // GET: api/CarsInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarsInfo>> GetCarsInfo(string id)
        {
            return Ok(_bookingRepository.GetCar(id));
        }

        // PUT: api/CarsInfoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarsInfo(string id, CarsInfo carsInfo)
        {
            if (id != carsInfo.Id)
            {
                return BadRequest();
            }

            _bookingRepository.PutCar(id, carsInfo);

            return NoContent();
        }

        // POST: api/CarsInfoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CarsInfo>> PostCarsInfo(CarsInfo carsInfo)
        {
            _bookingRepository.PostCar(carsInfo);
            return CreatedAtAction("GetCarsInfo", new { id = carsInfo.Id }, carsInfo);
        }

        // DELETE: api/CarsInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CarsInfo>> DeleteCarsInfo(string id)
        {
            IQueryable<CarsInfo> carsInfo = (IQueryable<CarsInfo>)_bookingRepository.DeleteCar(id);
            if (carsInfo.Count() == 0)
            {
                return NotFound();
            }

            return Ok(carsInfo);
        }
    }
}
