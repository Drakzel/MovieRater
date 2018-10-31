using MovieRater;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Xunit;

namespace CompanyName.MovieRater.UnitTesting
{
    public class UnitTest1
    {
        static string Path = "../../../../../../ratings.json";

        public HashSet<Review> reviews { get; set; }
        public HashSet<Review> reviewsTop { get; set; }

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

        [Fact]
        public void NumberOfReviewsOfUserTest()
        {
            IMovieFunctions mf = new MovieFunctions
            {
                Reviews = reviewsTop
            };
            int res = mf.NrOfReviews(3);
            int exp = 2012;
            Assert.Equal(res, exp);
        }

        [Fact]
        public void NumberOfReviewsOfUserTestPerfTest()
        {
            IMovieFunctions mf = new MovieFunctions
            {
                Reviews = reviews
            };
            Random rand = new Random();
            Stopwatch timer = Stopwatch.StartNew();
            mf.NrOfReviews(rand.Next(1,999));
            timer.Stop();
            Assert.True(timer.ElapsedMilliseconds < 4000);

        }
    }
}
