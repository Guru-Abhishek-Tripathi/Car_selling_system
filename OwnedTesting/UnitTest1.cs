using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Owned_car.Controllers;
using Owned_car.Models;
using Owned_car.Repository;
using System.Collections.Generic;
using System.Linq;

namespace OwnedTesting
{
    public class Tests
    {
        public List<Owned> obj1 = new List<Owned>();
        //{
        //    new Owned
        //    {
        //        CarId="C001", CusId="CUS12", Installment = 34564, NoOfInstallments = 24, Payment = "EMI"
        //    }
        //};
        //OwnedsController obj2 = new OwnedsController();

        IQueryable<Owned> cdata;
        Mock<DbSet<Owned>> mockSet;
        Mock<Simulation_dbContext> Ownedcontextmock;
        [SetUp]
        public void Setup()
        {

            obj1 = new List<Owned>()
            {
                new Owned{ CarId="C001", CusId="CUS12", Installment = 34564, NoOfInstallments = 24, Payment = "EMI" }
            };
            cdata = obj1.AsQueryable();
            mockSet = new Mock<DbSet<Owned>>();
            mockSet.As<IQueryable<Owned>>().Setup(m => m.Provider).Returns(cdata.Provider);
            mockSet.As<IQueryable<Owned>>().Setup(m => m.Expression).Returns(cdata.Expression);
            mockSet.As<IQueryable<Owned>>().Setup(m => m.ElementType).Returns(cdata.ElementType);
            mockSet.As<IQueryable<Owned>>().Setup(m => m.GetEnumerator()).Returns(cdata.GetEnumerator());
            var p = new DbContextOptions<Simulation_dbContext>();
            Ownedcontextmock = new Mock<Simulation_dbContext>(p);
            Ownedcontextmock.Setup(x => x.Owned).Returns(mockSet.Object);

        }


        [Test]
        public void Test1()
        {
            var carsService = new OwnedCarRepository(Ownedcontextmock.Object);
            var carslist = carsService.GetCar("C001");
            Assert.AreEqual(1, carslist.Count());
        }



        [Test]
        public void Test2()
        {
            var carsService = new OwnedCarRepository(Ownedcontextmock.Object);
            var x = carsService.DeleteCar("C001");
            Assert.IsNotNull(x);
        }
    }
}