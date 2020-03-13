﻿namespace Movie_project.Models
{
    public class Rating
    {
        public int MovieId { get; set; }

        public Movie Movie { get; set; }

        public int ReviewerId { get; set; }

        public Reviewer Reviewer { get; set; }

        public int ReviewStars { get; set; }

        public int NumOfRatings { get; set; }
    }
}