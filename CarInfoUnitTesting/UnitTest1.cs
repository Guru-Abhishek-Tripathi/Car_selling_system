using NUnit.Framework;
using booking_cars.Models;
using booking_cars.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Microsoft.EntityFrameworkCore;
using booking_cars.Repository;

namespace CarInfoUnitTesting
{
    public class Tests
    {
        public List<CarsInfo> obj1 = new List<CarsInfo>();
            
        //Simulation_dbContext xx = new Simulation_dbContext();
        // obj2 = new CarsInfoesController();

        IQueryable<CarsInfo> cdata;
        Mock<DbSet<CarsInfo>> mockSet;
        Mock<Simulation_dbContext> carsinfocontextmock;
        [SetUp]
        public void Setup()
        {

            obj1 = new List<CarsInfo>()
            {
                new CarsInfo{ CName="hgjasg", Id="C001", Model ="sdgd", Origin = new DateTime(2020,12,12), Price=548458}
            };
            cdata = obj1.AsQueryable();
            mockSet = new Mock<DbSet<CarsInfo>>();
            mockSet.As<IQueryable<CarsInfo>>().Setup(m => m.Provider).Returns(cdata.Provider);
            mockSet.As<IQueryable<CarsInfo>>().Setup(m => m.Expression).Returns(cdata.Expression);
            mockSet.As<IQueryable<CarsInfo>>().Setup(m => m.ElementType).Returns(cdata.ElementType);
            mockSet.As<IQueryable<CarsInfo>>().Setup(m => m.GetEnumerator()).Returns(cdata.GetEnumerator());
            var p = new DbContextOptions<Simulation_dbContext>();
            carsinfocontextmock = new Mock<Simulation_dbContext>(p);
            carsinfocontextmock.Setup(x => x.CarsInfo).Returns(mockSet.Object);

        }


        

        [Test]
        public void Test1()
        {
            var carsService = new BookingRepository(carsinfocontextmock.Object);
            var carslist = carsService.GetCar("C001");
            Assert.AreEqual(1, carslist.Count());
        }
      
        

        [Test]
        public void Test2()
        {
            var carsService = new BookingRepository(carsinfocontextmock.Object);
            var x = carsService.DeleteCar("C002");
            Assert.IsNotNull(x);
        }
    }
}