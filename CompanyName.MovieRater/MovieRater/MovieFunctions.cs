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
            int count = Reviews.Where(x => x.Reviewer == RID).Count();
            return count;
        }
    }

}
