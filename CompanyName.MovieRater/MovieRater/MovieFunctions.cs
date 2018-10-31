using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MovieRater
{
    public class MovieFunctions : IMovieFunctions
    {
        public HashSet<Review> Reviews { get; set; }
        public HashSet<Review> ReviewsTop { get; set; }

        public List<Review> ReadJson(string path)
        {
            List<Review> reviews = new List<Review>();

            using (StreamReader sr = new StreamReader(path))
            {
                string json = sr.ReadToEnd();
                reviews = JsonConvert.DeserializeObject<List<Review>>(json);
                Reviews = reviews.ToHashSet();
            }
            return null;
        }
        public int NrOfReviews(int RID)
        {
            int c = Reviews.Where(x => x.Reviewer == RID).Count();
            return c;
        }

        public double AvgOfReviewer(int RID)
        {
            double avg = Reviews.Where(x => x.Reviewer == RID).Average(x => x.Grade);
            return avg;
        }

        public int MovRevByGrade(int MID, int grade)
        {
            var gc = Reviews.Where(review => MID == review.Movie && review.Grade == grade).Count();
            return gc;
        }

        public int MovieRevCount(int MID)
        {
            int c = Reviews.Where(x => x.Movie == MID).Count(); ;
            return c;
        }

        public double MovieRevAvg(int MID)
        {
            var avg = Reviews.Where(review => MID == review.Movie).Average(r => r.Grade);

            return avg;
        }
    }

}
