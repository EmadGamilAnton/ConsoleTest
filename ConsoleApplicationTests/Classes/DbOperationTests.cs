using ConsoleApplication.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ConsoleApplication.Classes.Tests
{
    [TestClass()]
    public class DbOperationTests 
    {
        [TestMethod()]
        public void InsertRecordTest()
        {
            var data = new List<customer>
            {
                new customer { cust_name = "AAAAA",cust_address="AAA" }
                
            }.AsQueryable();

            var mockSet = new Mock<DbSet<customer>>();
            mockSet.As<IQueryable<customer>>().Setup(m => m.Provider).Returns(data.Provider);

            var mockContext = new Mock<pharmacydbEntities>();
            mockContext.Setup(c => c.customers).Returns(mockSet.Object);

            var service  = new DbOperation(mockContext.Object);
            var customer = service.InsertRecord("EmadEmad","AAA");
                       
            Assert.AreEqual(customer,"EmadEmad");
        }
    }
}