using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Selling_Car.Controllers;
using Selling_Car.Models;
using Selling_Car.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomersUnitTesting
{
    public class Tests
    {
        public List<Customer> obj1 = new List<Customer>();
        //{
        //    new Customer
        //    {
        //        CusAddress="Badlapur", CusDob = new DateTime(1997,12,8), CusEmail = "rishi@gmail.com", CusGender="male", CusId = "CUS12", CusName="Kishan", CusPassword="KK@123", CusPhone=7897945673
        //    }
        //};
        //Simulation_dbContext xx = new Simulation_dbContext();
        //CustomersController obj2 = new CustomersController();
        IQueryable<Customer> cdata;
        Mock<DbSet<Customer>> mockSet;
        Mock<Simulation_dbContext> Customercontextmock;
        [SetUp]
        public void Setup()
        {

            obj1 = new List<Customer>()
            {
                new Customer{CusAddress="Badlapur", CusDob = new DateTime(1997,12,8), CusEmail = "rishi@gmail.com", CusGender="male", CusId = "CUS12", CusName="Kishan", CusPassword="KK@123", CusPhone=7897945673}
            };
            cdata = obj1.AsQueryable();
            mockSet = new Mock<DbSet<Customer>>();
            mockSet.As<IQueryable<Customer>>().Setup(m => m.Provider).Returns(cdata.Provider);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(cdata.Expression);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(cdata.ElementType);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(cdata.GetEnumerator());
            var p = new DbContextOptions<Simulation_dbContext>();
            Customercontextmock = new Mock<Simulation_dbContext>(p);
            Customercontextmock.Setup(x => x.Customer).Returns(mockSet.Object);

        }


        [Test]
        public void Test1()
        {
            var carsService = new CustomerRespository(Customercontextmock.Object);
            var carslist = carsService.GetCustomer("CUS01");
            Assert.AreEqual(1, carslist.Count());
        }



        [Test]
        public void Test2()
        {
            var carsService = new CustomerRespository(Customercontextmock.Object);
            var x = carsService.DeleteCustomer("CUS12");
            Assert.IsNotNull(x);
        }
    }
}