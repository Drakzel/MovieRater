using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieRater;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace CompanyName.MovieRater.MSTest
{
    [TestClass]
    public class UnitTest1
    {

        private const string Path = "../../../../../../ratings.json";

        private readonly HashSet<Review> reviews = new HashSet<Review>();
        private readonly HashSet<Review> reviewsTop = new HashSet<Review>();


        public UnitTest1()
        {
            reviewsTop = ReadTop10(Path).ToHashSet();
            reviews = ReadJson(Path).ToHashSet();
        }

        #region ReadFile

        public List<Review> ReadJson(string path)
        {
            List<Review> reviews = new List<Review>();

            using (StreamReader sr = new StreamReader(path))
            {
                string json = sr.ReadToEnd();
                reviews = JsonConvert.DeserializeObject<List<Review>>(json);

            }
            return reviews;
        }

        public List<Review> ReadTop10(string path)
        {
            List<Review> reviews = new List<Review>();

            using (StreamReader sr = new StreamReader(path))
            {
                sr.ReadLine();
                for (int i = 0; i < 10; i++)
                {
                    string json = sr.ReadLine();
                    json = json.Substring(0, json.Length - 2);
                    reviews.Add(JsonConvert.DeserializeObject<Review>(json));
                }
            }

            return reviews;
        }
        #endregion

        #region Number Of Reviews Of User Test
        [TestMethod]
        public void NrofRevsofUserTest()
        {
            IMovieFunctions mf = new MovieFunctions
            {
                Reviews = reviews
            };

            int res = mf.NrOfReviews(3);
            int exp = 2012;

            Assert.AreEqual(exp, res);
        }

        [TestMethod]
        public void NumberOfReviewsOfUserTestPerfTest()
        {
            IMovieFunctions mf = new MovieFunctions
            {
                Reviews = reviews
            };

            Random rand = new Random();
            Stopwatch timer = Stopwatch.StartNew();
            mf.NrOfReviews(rand.Next(1, 999));
            timer.Stop();

            Assert.IsTrue(timer.ElapsedMilliseconds < 4000);
        }
        #endregion

        #region Avrage Of Reviewer Test
        [TestMethod]
        public void AvgofRevTest()
        {
            IMovieFunctions mf = new MovieFunctions
            {
                Reviews = reviews
            };

            double exp = 3.64115308151093;
            double res = mf.AvgOfReviewer(3);

            Assert.AreEqual(exp, res);
        }
        [TestMethod]
        public void AvgofRevPerfTest()
        {
            IMovieFunctions mr = new MovieFunctions
            {
                Reviews = reviews
            };

            Random rnd = new Random();
            Stopwatch sw = Stopwatch.StartNew();
            double res = mr.AvgOfReviewer(rnd.Next(1, 999));
            sw.Stop();

            Assert.IsTrue(sw.ElapsedMilliseconds < 4000);
        }

        #endregion

        #region MovieReviewedByGrade
        [TestMethod]
        public void MovRevCountByGradeTest()
        {
            IMovieFunctions mr = new MovieFunctions
            {
                Reviews = reviews
            };

            int res = mr.MovRevCountByGrade(2413320, 4);
            int exp = 19;

            Assert.AreEqual(exp, res);
        }

        [TestMethod]
        public void MovRevByGradeCountPerfTest()
        {
            IMovieFunctions mr = new MovieFunctions
            {
                Reviews = reviews
            };

            Stopwatch sw = Stopwatch.StartNew();
            mr.MovRevCountByGrade(2413320, 2);
            sw.Stop();

            Assert.IsTrue(sw.ElapsedMilliseconds < 4000);

        }
        #endregion

        #region MovieReviedCount
        [TestMethod]
        public void MovRevCountTest()
        {
            IMovieFunctions mr = new MovieFunctions
            {
                Reviews = reviews
            };

            int res = mr.MovieRevCount(2534508);
            int exp = 44;

            Assert.AreEqual(exp, res);
        }

        [TestMethod]
        public void MovRevCountPerfTest()
        {
            IMovieFunctions mr = new MovieFunctions
            {
                Reviews = reviews
            };

            Random rnd = new Random();
            Stopwatch sw = Stopwatch.StartNew();
            int res = mr.MovieRevCount(2534508);
            sw.Stop();

            Assert.IsTrue(sw.ElapsedMilliseconds < 4000);
        }

        #endregion

        #region Movie Review Average
        [TestMethod]
        public void AvgRateTest()
        {
            IMovieFunctions mr = new MovieFunctions
            {
                Reviews = reviews
            };

            double res = mr.MovieRevAvg(2534508);
            var exp = 3.15909090909091;

            Assert.AreEqual(exp, res);
        }

        [TestMethod]
        public void AvgRatePerfTest()
        {
            IMovieFunctions mr = new MovieFunctions
            {
                Reviews = reviews
            };

            Stopwatch sw = Stopwatch.StartNew();
            mr.MovieRevAvg(1488844);
            sw.Stop();

            Assert.IsTrue(sw.ElapsedMilliseconds < 4000);
        }
        #endregion

        #region Movie Reviewed By Grade 
        [TestMethod]
        public void MovRevByGradeTest()
        {
            IMovieFunctions mr = new MovieFunctions
            {
                Reviews = reviews
            };

            double res = mr.MovieReviewedByGrade(2023084, 5);
            int exp = 4;

            Assert.AreEqual(exp, res);
        }

        [TestMethod]
        public void MovRevByGradePerfTest()
        {

            IMovieFunctions mr = new MovieFunctions
            {
                Reviews = reviews
            };

            Stopwatch sw = Stopwatch.StartNew();
            mr.MovieReviewedByGrade(2023084, 1);
            sw.Stop();

            Assert.IsTrue(sw.ElapsedMilliseconds < 4000);
        }
        #endregion

        #region Most Top Rated Movies
        [TestMethod]
        public void MostTopRatedMovTest()
        {
            IMovieFunctions mr = new MovieFunctions
            {
                Reviews = reviews
            };

            var res = mr.MoviesMostTopRated().Count();
            int exp = 6;

            Assert.AreEqual(exp, res);
        }

        [TestMethod]
        public void MostTopRatedMovPerfTest()
        {

            IMovieFunctions mr = new MovieFunctions
            {
                Reviews = reviews
            };

            Stopwatch sw = Stopwatch.StartNew();
            mr.MoviesMostTopRated();
            sw.Stop();

            Assert.IsTrue(sw.ElapsedMilliseconds < 4000);
        }
        #endregion

        #region Most Reviews By Reviewer
        [TestMethod]
        public void MostRevByRevTest()
        {
            IMovieFunctions mr = new MovieFunctions
            {
                Reviews = reviews
            };

            var res = mr.ReviewerMostReviews().Count();
            int exp = 1;

            Assert.AreEqual(exp, res);
        }

        [TestMethod]
        public void MostRevByRevPerfTest()
        {

            IMovieFunctions mr = new MovieFunctions
            {
                Reviews = reviews
            };

            Stopwatch sw = Stopwatch.StartNew();
            mr.ReviewerMostReviews().Count();
            sw.Stop();

            Assert.IsTrue(sw.ElapsedMilliseconds < 4000);
        }
        #endregion

        #region Number of Top Movies Ord. By Avg. Rating
        [TestMethod]
        public void NrBestAvgTest()
        {
            IMovieFunctions mr = new MovieFunctions
            {
                Reviews = reviews
            };

            int g = 5;
            foreach (int i in mr.BestMovies(10))
            {
                Review r = reviews.FirstOrDefault(rev => rev.Movie == i);
                Assert.IsTrue(g >= r.Grade);
            }
        }

        [TestMethod]
        public void NrBestAvgPerfTest()
        {

            IMovieFunctions mr = new MovieFunctions
            {
                Reviews = reviews
            };

            Stopwatch sw = Stopwatch.StartNew();
            mr.BestMovies(10);
            sw.Stop();
            Assert.IsTrue(sw.ElapsedMilliseconds <= 4000);
        }
        #endregion

        #region Movies of Reviewers
        [TestMethod]
        public void MovofRevTest()
        {
            IMovieFunctions mr = new MovieFunctions
            {
                Reviews = reviews
            };

            List<int> exp = reviews.OrderByDescending(m => m.Grade).ThenByDescending(m => m.Date).Select(m => m.Movie).ToList();
            List<int> res = mr.ReviewersMovies(1);

            Assert.AreEqual(exp, res);
        }

        [TestMethod]
        public void MovofRevPerfTest()
        {

            IMovieFunctions mr = new MovieFunctions
            {
                Reviews = reviews
            };

            Stopwatch sw = Stopwatch.StartNew();
            mr.ReviewersMovies(1);
            sw.Stop();
            Assert.IsTrue(sw.ElapsedMilliseconds <= 4000);
        }
        #endregion

        #region Reviewers of Movies
        [TestMethod]
        public void RevOfMovTest()
        {
            IMovieFunctions mr = new MovieFunctions
            {
                Reviews = reviews
            };

            List<int> exp = new List<int> { 393 };

            Assert.AreEqual(exp, mr.MovieReviews(2342338));
            Assert.AreEqual(exp, mr.MovieReviews(1591957));

        }

        [TestMethod]
        public void RevOfMovPerfTest()
        {

            IMovieFunctions mr = new MovieFunctions
            {
                Reviews = reviews
            };

            Stopwatch sw = Stopwatch.StartNew();
            mr.MovieReviews(2342338);
            sw.Stop();
            Assert.IsTrue(sw.ElapsedMilliseconds <= 4000);
        }
        #endregion
    }
}
