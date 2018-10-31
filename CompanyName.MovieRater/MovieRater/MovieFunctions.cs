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
        static string path = @"C:\Users\Me\Desktop\ratings.json";
        
        List<Review> reviews = JsonConvert.DeserializeObject<List<Review>>(File.ReadAllText(path));

        public List<Review> GetAll()
        {
            return reviews;
        }

        public Review GetReviewer(int id)
        {
            return reviews.FirstOrDefault(m => m.Reviewer == id);
        }
    }
}
