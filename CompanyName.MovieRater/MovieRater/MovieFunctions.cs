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
        static string Path = "../../../../../../ratings.json";

        public HashSet<Review> Reviews { get; set; }
        public HashSet<Review> ReviewsTop { get; set; }

        public List<Review> GetAll()
        {
            Reviews = ReadJson(Path).ToHashSet();
            return Reviews.ToList();
        }

        public List<Review> GetTop()
        {
            ReviewsTop = ReadTop10(Path).ToHashSet();
            return ReviewsTop.ToList();
        }

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

    }

}
