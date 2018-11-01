using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRater
{
    /// <summary>
    /// Review Entitty class. Each Row in JSON become one entity.
    /// </summary>
    public class Review
    {
        public int Reviewer { get; set; }
        public int Movie { get; set; }
        public int Grade { get; set; }
        public DateTime Date { get; set; }
    }
}
