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
            int res = x.NrOfReviews(3);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
