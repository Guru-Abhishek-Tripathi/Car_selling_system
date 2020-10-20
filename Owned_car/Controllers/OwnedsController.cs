using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Owned_car.Models;
using Owned_car.Repository;

namespace Owned_car.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnedsController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(OwnedsController));
        private readonly IOwnedCarRepository _OwnedCarRepository;

        public OwnedsController(IOwnedCarRepository OwnedCarRepository)
        {
            _OwnedCarRepository = OwnedCarRepository;
        }

        // GET: api/Owneds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Owned>>> GetOwned()
        {
            _log4net.Info("Controller of Owneds");
            return Ok(_OwnedCarRepository.GetCar());
        }

        // GET: api/Owneds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Owned>> GetOwned(string id)
        {
            return Ok(_OwnedCarRepository.GetCar(id));
        }

        // PUT: api/Owneds/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOwned(string id, Owned owned)
        {
            if (id != owned.CusId)
            {
                return BadRequest();
            }

            //_context.Entry(owned).State = EntityState.Modified;

            
                _OwnedCarRepository.PutCar(id, owned);
                //await _context.SaveChangesAsync();
            
            

            return NoContent();
        }

        // POST: api/Owneds
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Owned>> PostOwned(Owned owned)
        {
            //_context.Owned.Add(owned);
            
                _OwnedCarRepository.PostCar(owned);
                //await _context.SaveChangesAsync();
            
            

            return CreatedAtAction("GetOwned", new { id = owned.CusId }, owned);
        }

        // DELETE: api/Owneds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Owned>> DeleteOwned(string id)
        {
            //var owned = await _context.Owned.FindAsync(id);
            IQueryable<Owned> owned = (IQueryable<Owned>)_OwnedCarRepository.DeleteCar(id);
            if (owned.Count() == 0)
            {
                return NotFound();
            }

            //_context.Owned.Remove(owned);
            //_context.SaveChangesAsync();

            //return owned;
            return Ok(owned);
        }


        //private bool OwnedExists(string id)
        //{

        //    return _context.Owned.Any(e => e.CusId == id);
        //}
    }
}
