using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRater
{
    public interface IMovieFunctions
    {
        HashSet<Review> Reviews { get; set; }
        HashSet<Review> ReviewsTop { get; set; }
        List<Review> GetAll();
        List<Review> GetTop();
    }
}
