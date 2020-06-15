using System;
namespace adamBrittain_cab301_assignment
{
    //Movie class to create Movie 0bject
    public class Movie
    {
        private string title;
        private string starring;
        private string director;
        private int duration;
        private string genre;
        private string classification;
        private DateTime releaseDate;
        private int timesRented = 0;
        private int copiesAvail = 0;


        public Movie()
        {

        }

        public Movie(string title, string starring, string director,
        int duration, string genre, string classification,
        DateTime releaseDate, int copiesAvail, int timesRented)
        {
            this.title = title;
            this.starring = starring;
            this.director = director;
            this.duration = duration;
            this.genre = genre;
            this.classification = classification;
            this.releaseDate = releaseDate;
            this.copiesAvail = copiesAvail;
            this.timesRented = timesRented;
        }


        //Getter functions for private class members
        public string GetTitle()
        {
            return this.title;
        }

        public string GetStarring()
        {
            return this.starring;
        }

        public string GetDirector()
        {
            return this.director;
        }

        public int GetDuration()
        {
            return this.duration;
        }

        public string GetGenre()
        {
            return this.genre;
        }

        public string GetClassification()
        {
            return this.classification;
        }

        public DateTime GetReleaseDate()
        {
            return this.releaseDate;
        }

        public int GetTimesRented()
        {
            return this.timesRented;
        }

        public int GetCopiesAvail()
        {
            return this.copiesAvail;
        }



        //Setter functions for private class members
        public void IncreaseTimesRented()
        {
            this.timesRented++;
        }

        public void IncreaseCopiesAvail(int n)
        {
            this.copiesAvail = this.copiesAvail + n;
        }

        public void DecreaseCopiesAvail()
        {
            this.copiesAvail--;
        }

    }
}
