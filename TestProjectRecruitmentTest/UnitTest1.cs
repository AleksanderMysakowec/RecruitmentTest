using RecruitmentTest.RepositoryDirectory;
using System.Text.Json;

namespace TestProjectRecruitmentTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            FindOrderCSV findOrderCSV = new FindOrderCSV("D:\\test.csv");

            var result = findOrderCSV.FindOrders("1", DateTime.Now, DateTime.Now, new string[] { "1" });
            Assert.AreEqual(JsonSerializer.Serialize(new { resul = "no items" }), result);

           

        }

        [TestMethod]
        public void TestMethod2()
        {
            FindOrderCSV findOrderCSV = new FindOrderCSV(null);

            var result = findOrderCSV.FindOrders("1", DateTime.Now, DateTime.Now, new string[] { "1" });

            Assert.AreEqual(JsonSerializer.Serialize(new { resul = "no set source file" }), result);


        }
    }
}