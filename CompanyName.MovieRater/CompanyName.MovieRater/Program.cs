using MovieRater;
using System;

namespace CompanyName.MovieRater
{
    class Program
    {
        static void Main(string[] args)
        {
            string Path = "../../../../../../ratings.json";
            IMovieFunctions x = new MovieFunctions();
            x.ReadJson(Path);
            var asd = x.ReviewerMostReviews().Count; 
            Console.WriteLine(asd);
            Console.ReadLine();
        }
    }
}
