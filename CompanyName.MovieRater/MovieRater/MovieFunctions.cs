using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MovieRater
{
    /// <summary>
    /// Implementation Class for IMovieFunctions Interface.
    /// </summary>
    public class MovieFunctions : IMovieFunctions
    {
        public HashSet<Review> Reviews { get; set; }

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

        public int MovRevCountByGrade(int RID, int grade)
        {
            var gc = Reviews.Where(review => RID == review.Reviewer && review.Grade == grade).Count();

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

        public Review GetReviewer(int id)
        {
            return Reviews.FirstOrDefault(m => m.Reviewer == id);
        }

        public int MovieReviewedByGrade(int MID, int grade)
        {
            var gc = Reviews.Where(rev => MID == rev.Movie && rev.Grade == grade).Count();

            return gc;
        }

        public List<int> MoviesMostTopRated()
        {
            List<int> tr = Reviews.Where(r => r.Grade == 5).Select(r => r.Movie).ToList();

            List<int> list = new List<int>();
            int max = 0;

            for (int i = 0; i < tr.Count(); i++)
            {
                if (tr[i] == max)
                {
                    list.Add(i + 1);
                }

                if (tr[i] > max)
                {
                    list.Clear();
                    max = tr[i];
                    list.Add(i + 1);
                }
            }

            return list;
        }

        public List<int> ReviewerMostReviews()
        {
            var mr = Reviews.GroupBy(r => r.Reviewer).Select(g => g.Count()).ToList();

            List<int> list = new List<int>();
            int max = 0;

            for (int i = 0; i < mr.Count(); i++)
            {
                if (mr[i] == max)
                {
                    list.Add(i + 1);
                }

                if (mr[i] > max)
                {
                    list.Clear();
                    max = mr[i];
                    list.Add(i + 1);
                }
            }

            return list;
        }

        public List<int> BestMovies(int num)
        {
            var R = Reviews.GroupBy(r => r.Movie).Select(res => new { mov = res.Key, avg = res.Average(m => m.Grade) });
            var ord = R.OrderByDescending(m => m.avg).Take(num).Select(m => m.mov).ToList();

            return ord;
        }

        public List<int> ReviewersMovies(int RID)
        {
            List<int> rm = Reviews.Where(m => m.Reviewer == RID).OrderByDescending(m => m.Grade).ThenByDescending(m => m.Date).Select(m => m.Movie).ToList();

            return rm;
        }

        public List<int> MovieReviews(int MID)
        {
            List<int> rev = Reviews.Where(r => r.Movie == MID).OrderByDescending(m => m.Grade).ThenByDescending(m => m.Date).Select(m => m.Reviewer).ToList();

            return rev;
        }
    }
}
