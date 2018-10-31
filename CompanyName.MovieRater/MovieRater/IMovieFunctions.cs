using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRater
{
    public interface IMovieFunctions
    {
        HashSet<Review> Reviews { get; set; }
        HashSet<Review> ReviewsTop { get; set; }
        List<Review> ReadJson(string path);

        double AvgOfReviewer(int RID);
        int NrOfReviews(int RID);
        int MovRevByGrade(int MID, int grade);
        int MovieRevCount(int MID);
    }
}
