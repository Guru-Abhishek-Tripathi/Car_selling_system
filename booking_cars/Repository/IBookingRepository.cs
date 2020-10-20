using booking_cars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace booking_cars.Repository
{
    public interface IBookingRepository
    {
        public List<CarsInfo> GetCar();
        public IQueryable<CarsInfo> GetCar(string id);
        public CarsInfo PutCar(string id, CarsInfo carsInfo);
        public void PostCar(CarsInfo carsInfo);
        public IQueryable<CarsInfo> DeleteCar(string id);
    }
}
