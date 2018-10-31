using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieRater;

namespace CompanyName.MSTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IMovieFunctions x = new MovieFunctions();

            var reviewer = x.GetReviewer(45);
            Assert.IsTrue(reviewer != null);
        }
    }
}
