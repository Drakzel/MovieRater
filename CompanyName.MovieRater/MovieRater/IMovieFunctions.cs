using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRater
{
    /// <summary>
    /// Method Interface for project
    /// </summary>
    public interface IMovieFunctions
    {
        HashSet<Review> Reviews { get; set; }
        List<Review> ReadJson(string path);

        #region Requirements methods + Documentation
        /// <summary>
        /// Method for getting the Average grade given Reviewer had given.
        /// </summary>
        /// <param name="rID">Reviewer parameter</param>
        /// <returns>The average grade given by the Reviewer with RID.</returns>
        double AvgOfReviewer(int RID);
        /// <summary>
        /// Method for Getting the number of reviews by given Reviewer.
        /// </summary>
        /// <param name="RID">Reviewer parameter</param>
        /// <returns>The amount of reviews, Reviewer with RID has given</returns>
        int NrOfReviews(int RID);
        /// <summary>
        /// Method getting the amount of times a given Reviewer had given a movie given grade.
        /// </summary>
        /// <param name="RID">Reviewer parameter</param>
        /// <param name="grade">Grade parameter</param>
        /// <returns>The amount of times Reviewer RID has given a movie Grade grade</returns>
        int MovRevCountByGrade(int RID, int grade);
        /// <summary>
        /// Method for getting the amount of times a Movie was reviewed.
        /// </summary>
        /// <param name="MID">Movie parameter</param>
        /// <returns>The amount of times a given movie MID was reviewed.</returns>
        int MovieRevCount(int MID);
        /// <summary>
        /// Method for getting the average grade a Movie had recieved.
        /// </summary>
        /// <param name="MID">Movie Parameter</param>
        /// <returns>The average grade for Movie MID.</returns>
        double MovieRevAvg(int MID);
        /// <summary>
        /// Method for getting the amount of times a given movie recieved a given grade.
        /// </summary>
        /// <param name="mID">Movie parameter</param>
        /// <param name="grade">Grade parameter</param>
        /// <returns>The number of times the movie MID recieved the Grade grade.</returns>
        int MovieReviewedByGrade(int MID, int grade);
        /// <summary>
        /// Method for getting a list of Movies that had the best grade.
        /// </summary>
        /// <returns>The list of movies that were top rated.</returns>
        List<int> MoviesMostTopRated();
        /// <summary>
        /// Method for getting the Reviewer that had made the most reviews 
        /// </summary>
        /// <returns>The Reviewer that made the most reviews</returns>
        List<int> ReviewerMostReviews();
        /// <summary>
        /// Method for getting the method with the best score. Score is determined by rating average.
        /// </summary>
        /// <param name="num">Score parameter</param>
        /// <returns>The movie with the best score</returns>
        List<int> BestMovies(int num);
        /// <summary>
        /// Method for getting a list of movies a reviewer has reviewed
        /// </summary>
        /// <param name="RID">Reviewer parameter</param>
        /// <returns>The list of movies Reviewer RID has reviewed</returns>
        List<int> ReviewersMovies(int RID);
        /// <summary>
        /// Method for getting the Reviewers that had reviewed given movie.
        /// </summary>
        /// <param name="MID">Movie Parameter</param>
        /// <returns>The list of Reviewers that had reviewed Movie MID</returns>
        List<int> MovieReviews(int MID);
        #endregion
    }
}
