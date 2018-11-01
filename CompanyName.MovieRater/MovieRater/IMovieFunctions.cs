using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRater
{
    public interface IMovieFunctions
    {
        HashSet<Review> Reviews { get; set; }
        List<Review> ReadJson(string path);

        double AvgOfReviewer(int RID);
        int NrOfReviews(int RID);
        int MovRevByGrade(int MID, int grade);
        int MovieRevCount(int MID);
        double MovieRevAvg(int MID);
        int MovieReviewedByGrade(int MID, int grade);
        List<int> MoviesMostTopRated();
        List<int> ReviewerMostReviews();
        List<int> BestMovies(int num);
        List<int> ReviewersMovies(int RID);
        List<int> MovieReviews(int MID);
    }
}
