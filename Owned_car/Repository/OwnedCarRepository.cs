using Microsoft.EntityFrameworkCore;
using Owned_car.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Owned_car.Repository
{
    public class OwnedCarRepository : IOwnedCarRepository
    {
        private readonly Simulation_dbContext _context;

        public OwnedCarRepository(Simulation_dbContext context)
        {
            _context = context;
        }
        public IQueryable<Owned> DeleteCar(string id)
        {
            //_context.Owned.FindAsync(id);
            IQueryable<Owned> owned = _context.Owned.Where(a => a.CarId == id);
            _context.Owned.Remove(owned.FirstOrDefault());
            _context.SaveChangesAsync();
            return owned;
        }

        public List<Owned> GetCar()
        {
            return _context.Owned.ToList();
        }

        public IQueryable<Owned> GetCar(string id)
        {
            return _context.Owned.Where(a => a.CarId == id);
        }

        public void PostCar(Owned owned)
        {
            _context.Owned.Add(owned);
            _context.SaveChangesAsync();
        }

        public Owned PutCar(string id, Owned owned)
        {
            _context.Entry(owned).State = EntityState.Modified;
            _context.SaveChangesAsync();
            return owned;
        }
    }
}
