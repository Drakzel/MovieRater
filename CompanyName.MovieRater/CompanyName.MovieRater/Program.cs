using MovieRater;
using System;

namespace CompanyName.MovieRater
{
    class Program
    {
        static void Main(string[] args)
        {
            IMovieFunctions x = new MovieFunctions();

            var g = x.GetAll();
            foreach (var item in g)
            {
                Console.WriteLine("Reviewer ID: {0}, Movie ID: {1}, Grade: {2}, Date: {3}\n",
                    item.ReviewerId, item.MovieId, item.GivenGrade, item.Date);
            }
            Console.ReadLine();
        }
    }
}
