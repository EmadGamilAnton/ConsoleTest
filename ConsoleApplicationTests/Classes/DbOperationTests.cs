using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ConsoleApplication.Classes.Tests
{
    [TestClass()]
    public class DbOperationTests 
    {
        [TestMethod()]
        public void InsertRecordTest()
        {
            Mock<DbOperation> obj = new Mock<DbOperation>();
            obj.Setup(x => x.InsertRecord("EmadEmad2","AlexMenof"));//.Returns("EmadEmad2");

            DbOperation obj2 = new DbOperation();
            bool isInserted = bool.Parse( obj2.InsertRecord("EmadEmad2", "AlexMenof"));
            
            Assert.AreEqual(isInserted, true);
            
        }
    }
}