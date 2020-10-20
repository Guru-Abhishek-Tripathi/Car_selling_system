using Owned_car.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Owned_car.Repository
{
    public interface IOwnedCarRepository
    {
        public List<Owned> GetCar();
        public IQueryable<Owned> GetCar(string id);
        public Owned PutCar(string id, Owned owned);
        public void PostCar(Owned owned);
        public IQueryable<Owned> DeleteCar(string id);

    }
}
