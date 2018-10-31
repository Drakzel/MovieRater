using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRater
{
    public interface IMovieFunctions
    {
        List<Review> GetAll();
        Review GetReviewer(int id);
    }
}
