using booking_cars.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace booking_cars.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly Simulation_dbContext _context;

        public BookingRepository(Simulation_dbContext context)
        {
            _context = context;
        }
        public IQueryable<CarsInfo> DeleteCar(string id)
        {
            IQueryable<CarsInfo> carsInfos = _context.CarsInfo.Where(a => a.Id == id);
            _context.CarsInfo.Remove(carsInfos.FirstOrDefault());
            _context.SaveChangesAsync();
            return carsInfos;
        }

        public List<CarsInfo> GetCar()
        {
            return _context.CarsInfo.ToList();
        }

        public IQueryable<CarsInfo> GetCar(string id)
        {
            return _context.CarsInfo.Where(a => a.Id == id);
        }

        public void PostCar(CarsInfo carsInfo)
        {
            _context.CarsInfo.Add(carsInfo);
            _context.SaveChangesAsync();
        }

        public CarsInfo PutCar(string id, CarsInfo carsInfo)
        {
            _context.Entry(carsInfo).State = EntityState.Modified;
            _context.SaveChangesAsync();
            return carsInfo;
        }
    }
}
