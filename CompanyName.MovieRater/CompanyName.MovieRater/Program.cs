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
            //var g = x.GetAll();
            //foreach (var item in g)
            //{
            //    Console.WriteLine("Reviewer ID: {0}, Movie ID: {1}, Grade: {2}, Date: {3}\n",
            //        item.Reviewer, item.Movie, item.Grade, item.Date);
            //}
            x.ReadJson(Path);
            var asd = x.ReviewerMostReviews().Count; 
            Console.WriteLine(asd);
            Console.ReadLine();
        }
    }
}
