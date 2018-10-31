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
        public HashSet<Review> Reviews { get; set; }
        public HashSet<Review> ReviewsTop { get; set; }
    }

}
