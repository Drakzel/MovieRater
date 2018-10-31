using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRater
{
    public class Review
    {
        public int ReviewerId { get; set; }
        public int MovieId { get; set; }
        public int GivenGrade { get; set; }
        public DateTime Date { get; set; }
    }
}
