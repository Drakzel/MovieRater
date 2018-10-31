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
            int asd = x.MovieRevCount(2534508); 
            Console.WriteLine(asd);
            Console.ReadLine();
        }
    }
}
