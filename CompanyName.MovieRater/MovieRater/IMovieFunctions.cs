﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRater
{
    public interface IMovieFunctions
    {
        HashSet<Review> Reviews { get; set; }
        HashSet<Review> ReviewsTop { get; set; }
    }
}
