﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRater
{
    public class Review
    {
        public int Reviewer { get; set; }
        public int Movie { get; set; }
        public int Grade { get; set; }
        public DateTime Date { get; set; }
    }
}